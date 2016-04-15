using System.Collections.Generic;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Core.Exceptions;
using UiTest.Mvcify;

namespace Mvcify.UI.Test
{
    public class SimpleFormController
    {
        private readonly ILog _log;
        private readonly SimpleForm _simpleForm;

        private SimpleModel _simpleModel;

        public SimpleFormController(ILog log, SimpleForm simpleForm)
        {
            _log = log;
            _simpleForm = simpleForm;
            _simpleForm.SimpleFormController = this;
        }

        public void ShowDialog()
        {
            _simpleForm.Render(GetModel());
            _simpleForm.ShowDialog();
        }
        public void Show()
        {
            _simpleForm.Render(GetModel());
            _simpleForm.Show();
        }

        public SimpleForm GetView()
        {
            return _simpleForm;
        }

        public SimpleModel GetModel()
        {
            if (_simpleModel == null)
            {
                _simpleModel = new SimpleModel
                {
                    Name = "TestName",
                    Description = "TestDescription",
                    Product = "Test",
                    Products = new List<string> {"Test", "Test2", "Test3"},
                    IsPublic = false
                };
            }
            return _simpleModel;
        }

        public void Initialize(SimpleModel model)
        {
            _simpleModel = model;    
        }
        public bool ValidateName()
        {
            if (_simpleModel.HasName)
            {
                return true;
            }
            throw new ValidationException("Please specify a name.");
        }

        public bool ValidateDescription()
        {
            if (_simpleModel.HasDescription)
            {
                return true;
            }
            throw new ValidationException("Please specify a description.");
        }

        public bool ValidateProduct()
        {
            if (_simpleModel.HasProduct)
            {
                return true;
            }
            throw new ValidationException("Please specify a product.");
        }
    }
}