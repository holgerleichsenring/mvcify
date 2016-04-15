using System.Windows.Forms;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Mvcify.Core.Services.Interfaces;

namespace Mvcify.Core.Services.Installers
{
    public class MvcifyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<ReflectionHelper>());
            container.Register(
                Component.For<IDataBinder<TextBox>>().ImplementedBy(typeof (TextBoxDataBinder)).LifeStyle.Transient);
            container.Register(
                Component.For<IDataBinder<CheckBox>>().ImplementedBy(typeof (CheckBoxDataBinder)).LifeStyle.Transient);
            container.Register(
                Component.For<IDataBinder<ComboBox>>().ImplementedBy(typeof (CombobBoxDataBinder)).LifeStyle.Transient);

            container.Register(
                Component.For(typeof (DataBinder<>)).ImplementedBy(typeof (DataBinder<>)).LifeStyle.Transient);
            container.Register(
                Component.For(typeof (IDataBinderProxy<,,>))
                    .ImplementedBy(typeof (DataBinderProxy<,,>))
                    .LifeStyle.Transient);
            container.Register(
                Component.For(typeof (IDataBinderValidator<,,>))
                    .ImplementedBy(typeof (DataBinderValidator<,,>))
                    .LifeStyle.Transient);
            container.Register(Component.For<StringListComboBoxDataSourceBinder>());
        }
    }
}