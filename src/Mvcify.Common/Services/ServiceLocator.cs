using System;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Common.Services.Logging;

namespace Mvcify.Common.Services
{
    public class ServiceLocator
    {
        private static WindsorContainer _container;

        public static WindsorContainer Instance
        {
            get
            {
                if (_container == null)
                {
                    throw new Exception("ServiceLocator has to be initialized before usage.");
                }
                return _container;
            }
        }

        public static T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }

        public static void Initialize(IWindsorInstaller[] installers)
        {
            Initialize(installers, null);
        }
        public static void Initialize(IWindsorInstaller[] installers, IFacility[] facilities)
        {
            InitializeContainer(installers, facilities);
            InitializeLog();
        }

        internal static void InitializeLog()
        {
            //TODO: *consider breaking initialization of program when log cannot be initialized properly.
            log4net.Config.XmlConfigurator.Configure();
        }

        internal static void InitializeContainer(IWindsorInstaller[] installers, IFacility[] facilities)
        {
            var container = new WindsorContainer();
            container.AddFacility<LogTypeResolverFacility>();
            if (facilities != null)
            {
                foreach (var facility in facilities)
                {
                    container.AddFacility(facility);
                }
            }
            container.Install(installers);
            _container = container;
        }

        /// <summary>
        ///     Returns logger instance for specified type.
        /// </summary>
        /// <param name="type">type of the object the logger is created for.</param>
        /// <returns>ILog instance</returns>
        public static ILog GetLogger(Type type)
        {
            var logger = log4net.LogManager.GetLogger(type) as log4net.ILog;
            return new Log(logger);
        }

        /// <summary>
        ///     Returns logger instance for specified type.
        /// </summary>
        /// <typeparam name="T">type of the object the logger is created for.</typeparam>
        /// <returns>ILog instance</returns>
        public static ILog GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }
        public static void Dispose()
        {
            _container.Dispose();
        }
    }
}