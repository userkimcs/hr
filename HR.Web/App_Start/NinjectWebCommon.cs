[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HR.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HR.Web.App_Start.NinjectWebCommon), "Stop")]

namespace HR.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using HR.Data;
    using HR.Data.Contracts;
    using HR.Data.Repository;
    using HR.Core.Contracts;
    using HR.Core.Services;

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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
            // kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
            kernel.Bind<IAdminService>().To<AdminService>();
            kernel.Bind<IEmployeeService>().To<EmployeeService>();
            kernel.Bind<IJobService>().To<JobService>();
            kernel.Bind<IDepartmentService>().To<DepartmentService>();
            kernel.Bind<IJobHistoryService>().To<JobHistoryService>();
            kernel.Bind<ILocationService>().To<LocationService>();
            kernel.Bind<IAttendanceService>().To<AttendanceService>();
        }
    }
}
