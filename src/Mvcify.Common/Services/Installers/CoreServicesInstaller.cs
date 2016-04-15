using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Mvcify.Common.Services.Interfaces;

namespace Mvcify.Common.Services.Installers
{
   public class CoreServicesInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IObjectFactory>().ImplementedBy<ObjectFactory>());
            container.Register(Component.For<IObjectReleaser>().ImplementedBy<ObjectReleaser>());
        }
    }
}
