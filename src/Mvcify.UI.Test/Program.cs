using System;
using Mvcify.Common.Services;
using Mvcify.Common.Services.Interfaces;
using UiTest.Mvcify;

namespace Mvcify.UI.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new ApplicationInitializer().Initialize();
            var objectFactory = ServiceLocator.Resolve<IObjectFactory>();
            var simpleFormController1 = objectFactory.Resolve<SimpleFormController>();
            var model = simpleFormController1.GetModel();

            var simpleFormController2 = ServiceLocator.Resolve<SimpleFormController>();
            simpleFormController2.Initialize(model);


            simpleFormController1.Show();
            simpleFormController2.ShowDialog();


            Console.WriteLine("{0} {1} {2}", model.Name, model.Description, model.Product);
        }
    }
}