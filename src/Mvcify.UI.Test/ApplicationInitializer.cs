using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Mvcify.Common.Services;
using Mvcify.Common.Services.Installers;
using Mvcify.Core.Services.Installers;
using Mvcify.UI.Test.Installers;

namespace Mvcify.UI.Test
{
    public class ApplicationInitializer
    {
        public void Initialize()
        {
            var installers = new List<IWindsorInstaller>
            {
                new MvcifyInstaller(),
                new CoreServicesInstaller(),
                new SimpleFormInstaller()
            };
            ServiceLocator.Initialize(installers.ToArray());
        }
    }
}