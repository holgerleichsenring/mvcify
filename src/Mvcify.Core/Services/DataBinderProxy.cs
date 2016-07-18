using System;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Core.Services.Interfaces;
using Mvcify.Core.Model;

namespace Mvcify.Core.Services
{
    public class DataBinderProxy<TModel, TControl, TResult> : IDataBinderProxy<TModel, TControl, TResult>
        where TControl : Control where TModel : class, INotifyPropertyChanged
    {
        private readonly ILog _log;
        private readonly IObjectFactory _objectFactory;
        private readonly ReflectionHelper _reflectionHelper;

        private ControlDataBindingModel<TModel, TControl, TResult> _controlDataBindingModel;
        private IDataBinder<TControl> _dataBinder;

        public DataBinderProxy(ILog log, IObjectFactory objectFactory, ReflectionHelper reflectionHelper)
        {
            _log = log;
            _log.Debug();
            _objectFactory = objectFactory;
            _reflectionHelper = reflectionHelper;
        }

        public void Initialize(ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel,
            IDataBinder<TControl> dataBinder)
        {
            _log.Debug();
            _controlDataBindingModel = controlDataBindingModel;
            _dataBinder = dataBinder;
        }

        public IDataBinderProxy<TModel, TControl, TResult> DataSource<TCollection>(
            Expression<Func<TModel, TCollection>> expression) where TCollection : ICollection
        {
            _log.Debug();
            var castedExpression = expression as Expression<Func<TModel, ICollection>>;
            _controlDataBindingModel.DataSourceExpression = castedExpression;
            var function = expression.Compile() as Func<TModel, ICollection>;
            _controlDataBindingModel.DataSourceFunction = function;
            _controlDataBindingModel.DataSourcePropertyInfo =
                _reflectionHelper.GetPropertyInfo(_controlDataBindingModel.Model, expression);
            _controlDataBindingModel.BindDataSourceFunction =
                delegate { _dataBinder.BindDataSource<TModel, TCollection, TResult>(_controlDataBindingModel); };
            return this;
        }

        public IDataBinderProxy<TModel, TControl, TResult> DataSource<TData>(IDataSourceBinder<TControl, TData> dataSourceBinder, TData data) where TData : class
        {
            _log.Debug();
            _controlDataBindingModel.BindDataSourceFunction =
                delegate { dataSourceBinder.Bind(_controlDataBindingModel.Model, _controlDataBindingModel.Control, data); };
            return this;
        }

        public IDataBinderProxy<TModel, TControl, TResult> OnChanged(Action<TModel> action)
        {
            _log.Debug();
            _controlDataBindingModel.ChangedAction = action;
            return this;
        }

        public IDataBinderValidator<TModel, TControl, TResult> Validate(Expression<Func<TModel, bool>> expression)
        {
            _log.Debug();
            _controlDataBindingModel.ValidateExpression = expression;
            _controlDataBindingModel.ValidateExpressionFunction = expression.Compile();

            var dataBinderValidator = _objectFactory.Resolve<IDataBinderValidator<TModel, TControl, TResult>>();
            dataBinderValidator.Initialize(_controlDataBindingModel);

            return dataBinderValidator;
        }
    }
}