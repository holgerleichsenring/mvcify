using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UiTest.Mvcify;

namespace Mvcify.UI.Test.Installers
{
    public class SimpleFormInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(SimpleForm)).LifeStyle.Transient);
            container.Register(Component.For(typeof(SimpleFormController)).LifeStyle.Transient);
        }
    }
}