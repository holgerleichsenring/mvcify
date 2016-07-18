using System.Windows.Forms;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Core.Services;
using UiTest.Mvcify;

namespace Mvcify.UI.Test
{
    public partial class SimpleForm : Form
    {
        private readonly DataBinder<SimpleModel> _dataBinder;
        private readonly ILog _log;
        private readonly StringListComboBoxDataSourceBinder _stringListComboBoxDataSourceBinder;

        public SimpleForm(ILog log, DataBinder<SimpleModel> dataBinder,
            StringListComboBoxDataSourceBinder stringListComboBoxDataSourceBinder)
        {
            _log = log;
            _log.Debug();
            _dataBinder = dataBinder;
            _stringListComboBoxDataSourceBinder = stringListComboBoxDataSourceBinder;
            InitializeComponent();
        }

        public SimpleFormController SimpleFormController { get; set; }

        public void Render(SimpleModel simpleModel)
        {
            _log.Debug("Render");
            _dataBinder.Bind(txtName, simpleModel, model => model.Name)
                .Validate(model => SimpleFormController.ValidateName())
                .OnSuccess(model => errorProvider1.Clear())
                .OnFailed((model, ex) => errorProvider1.SetError(txtName, ex.Message));

            _dataBinder.Bind(txtDescription, simpleModel, model => model.Description)
                .Validate(model => SimpleFormController.ValidateDescription())
                .OnSuccess(model => errorProvider1.Clear())
                .OnFailed((model, ex) => errorProvider1.SetError(txtDescription, ex.Message));

            _dataBinder.Bind(cboProducts, simpleModel, model => model.Product)
                .DataSource(_stringListComboBoxDataSourceBinder, simpleModel.Products)
                .Validate(model => SimpleFormController.ValidateProduct())
                .OnSuccess(model => errorProvider1.Clear())
                .OnFailed((model, ex) => errorProvider1.SetError(cboProducts, ex.Message));

            _dataBinder.Bind(chkIsPublic, simpleModel, model => model.IsPublic)
                .OnChanged(delegate(SimpleModel model)
                {
                    txtPublicComment.Visible = !model.IsPublic;
                    lblPublicComment.Visible = !model.IsPublic;
                });

            _dataBinder.Bind(simpleModel);
        }
    }
}