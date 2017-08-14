using NissanCart.Domain.Concrete;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NissanCartTest01.WebUi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NissanCartTest01.WebUi.App_Start.NinjectWebCommon), "Stop")]

namespace NissanCartTest01.WebUi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Moq;
    using NissanCart.Domain.Abstract;
    using System.Collections.Generic;
    using NissanCart.Domain.Entities;

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

            // register the respository into the karnel


            



            Mock<ISalesRespository> mock = new Mock<ISalesRespository>();

            mock.Setup(m => m.Sales).Returns(new List<Sales>
            {
                new Sales { StaffId=0,DealInfo="X Trail",VehicleInfo="Used Car",AmountPaid=1000,StaffInfo="Tommy",CUstomerID=6,Comment="Great Job on the deal"},
               new Sales { StaffId=20,DealInfo="350 Z",VehicleInfo="New Car",AmountPaid=1050000,StaffInfo="Lee",CUstomerID=90,Comment="good Car"},
               new Sales { StaffId=0,DealInfo="Qashqai",VehicleInfo="Used Car",AmountPaid=76000,StaffInfo="Jack",CUstomerID=6,Comment="Rude customer"},
               new Sales { StaffId=0,DealInfo="Navara",VehicleInfo="Used car",AmountPaid=90000,StaffInfo="John",CUstomerID=6,Comment="what a Van"}

            });

            //mocking object to the kernel or respository
            kernel.Bind<ISalesRespository>().ToConstant(mock.Object);

        }



    }
}
  