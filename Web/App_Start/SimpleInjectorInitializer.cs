using Data.Abstracts;
using Data.Concrete;
using Service.Concrete;

[assembly: WebActivator.PostApplicationStartMethod(typeof(Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Web.App_Start
{
    using Service.Abstracts;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {


            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<IPersonService, PersonService>(Lifestyle.Transient);
            container.Register<IUnitOfWork, GenericUnitOfWork>(Lifestyle.Scoped);
        }
    }
}