using Autofac;
using ShoppingMate.Core.Repository;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.Repository;
using ShoppingMate.Data.UnitOfWork;
using System.Reflection;
using System;
using Module = Autofac.Module;
using ShoppingMate.Service.Service.Concrete;
using ShoppingMate.Core.Service;
using ShoppingMate.Data.Context;
using ShoppingMate.Service.Mapper;

namespace ShoppingMate.API.Modules
{
    public class RepositoryAndServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<,>)).As(typeof(IGenericService<,>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));

            //builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
