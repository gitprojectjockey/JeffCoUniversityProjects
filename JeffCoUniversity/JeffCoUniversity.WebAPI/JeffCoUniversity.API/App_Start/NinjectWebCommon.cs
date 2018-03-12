[assembly: WebActivator.PreApplicationStartMethod(typeof(JeffCoUniversity.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(JeffCoUniversity.API.App_Start.NinjectWebCommon), "Stop")]

namespace JeffCoUniversity.API.App_Start
{
    using JeffCoUniversity.Common.Bindings;
    using JeffCoUniversity.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using System;
    using System.Web;


    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //NInject accross all 3 layers, 
            //without the TopLayer (JeffcO.API) knowing about the Buttom layer (JeffCo.Data) layer.
            //This means there will be no reference between the TopLayer (JeffcO.API)  and the BottomLayer (JeffCo.Data).
            //The only way JeffcO.API can talk to JeffcO.Data is through JeffCo.Service layer :>
            
            kernel.Load(new ServiceDependencyBindingModule());
            //Always use InRequestScope For Web Api 2
            kernel.Bind<IInstructorService>().To<InstructorService>();
          
        }        
    }
}
