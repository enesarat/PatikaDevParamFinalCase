using Newtonsoft.Json;
using ShoppingMate.Caching.Repository;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.API.Modules
{
    public class ProductCachedRepository : IProductRepository
    {
        private const string _productsKey = "productsCache";
        private const string _productsWithCategoyKey = "productsWithCategoryCache";

        private readonly IProductRepository _productRepository;
        private readonly RedisRepository _redisRepository;
        private readonly IDatabase _cacheDb;

        public ProductCachedRepository(IProductRepository repository, RedisRepository redisRepository)
        {
            _productRepository = repository;
            _redisRepository = redisRepository;
            _cacheDb = _redisRepository.GetDatabase(0);
            var db = redisRepository.GetDatabase(0);
            db.StringSet("eren", "arat");
        }

        private async Task<IEnumerable<Product>> CachingFromDatabase()
        {
            var products = await _productRepository.GetAllAsync();

            products.ToList().ForEach(p =>
            {
                string serializedAppartment = JsonConvert.SerializeObject(p);
                _cacheDb.HashSetAsync(_productsKey, p.Id, serializedAppartment);
            });

            return products;
        }
        private async Task<List<Product>> CachingFromDatabaseWithJoint()
        {
            var products = await _productRepository.GetProductsWithCategory();

            products.ForEach(p =>
            {
                string serializedAppartment = JsonConvert.SerializeObject(p);
                _cacheDb.HashSetAsync(_productsWithCategoyKey, p.Id, serializedAppartment);
            });

            return products;
        }

        public async Task AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
            var cacheStatus = await _cacheDb.KeyExistsAsync(_productsKey);
            if (!cacheStatus)
            {
                await CachingFromDatabase();
                await _cacheDb.HashSetAsync(_productsKey, entity.Id, JsonConvert.SerializeObject(entity));
            }
            else
            {
                await _cacheDb.HashSetAsync(_productsKey, entity.Id, JsonConvert.SerializeObject(entity));
            }
            await CachingFromDatabase();
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return await _productRepository.AnyAsync(expression);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
            if (!_cacheDb.KeyExists(_productsKey))
            {
                CachingFromDatabase();
                _cacheDb.HashDeleteAsync(_productsKey, entity.Id);
            }
            else
            {
                _cacheDb.HashDeleteAsync(_productsKey, entity.Id);
            }
            CachingFromDatabase();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var cacheStatus = await _cacheDb.KeyExistsAsync(_productsKey);
            if (!cacheStatus)
            {
                return await CachingFromDatabase();
            }

            var products = new List<Product>();
            var cachedProducts = await _cacheDb.HashGetAllAsync(_productsKey);
            foreach (var item in cachedProducts.ToList())
            {
                var product = JsonConvert.DeserializeObject<Product>(item.Value);
                products.Add(product);
            }

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if (_cacheDb.KeyExists(_productsKey))
            {
                var serializedProducts = await _cacheDb.HashGetAsync(_productsKey, id);
                return serializedProducts.HasValue ? JsonConvert.DeserializeObject<Product>(serializedProducts) : null;
            }

            var products = await CachingFromDatabase();
            var product = products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _productRepository.GetProductsWithCategory();
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
            if (!_cacheDb.KeyExists(_productsKey))
            {
                CachingFromDatabase();
                _cacheDb.HashDeleteAsync(_productsKey, entity.Id);
                _cacheDb.HashSetAsync(_productsKey, entity.Id, JsonConvert.SerializeObject(entity));
            }
            else
            {
                _cacheDb.HashDeleteAsync(_productsKey, entity.Id);
                _cacheDb.HashSetAsync(_productsKey, entity.Id, JsonConvert.SerializeObject(entity));
            }
            CachingFromDatabase();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.Where(expression);
        }
    }
}
