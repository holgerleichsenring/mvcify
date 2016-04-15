using Castle.MicroKernel.Facilities;

namespace Mvcify.Common.Services.Logging
{
    /// <summary>
    ///     http://joseoncode.com/2011/01/09/windsor-isubdependencyresolver-example/
    /// </summary>
    public class LogTypeResolverFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Resolver.AddSubResolver(new LogTypeResolver());
        }
    }
}