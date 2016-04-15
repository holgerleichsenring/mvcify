using System;
using System.Windows.Forms;

namespace Mvcify.Extensions.DataBind.Interfaces
{
    public interface IValidationResult<T, TResult>
    {
        IValidationResult<T, TResult> Success(Action<Control, T> success);
        IValidationResult<T, TResult> Fail(Action<Control, T> fail);
    }
}
