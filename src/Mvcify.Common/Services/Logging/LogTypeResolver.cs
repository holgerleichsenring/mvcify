using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using log4net;
// ReSharper disable All

namespace Mvcify.Common.Services.Logging
{
    public class LogTypeResolver : ISubDependencyResolver
    {
        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            ILog logger = LogManager.GetLogger(context.RequestedType);
            return new Log(logger);
        }

        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            return dependency.TargetType.Name == typeof (ILog).Name;
        }
    }
}