using System;
using Mvcify.Extensions.DataBind.Interfaces;

namespace Mvcify.Core.Extensions.DataBind.Interfaces
{
    public interface IValidation<T, TResult>
    {
        IValidationResult<T, TResult> Validate(Func<T, bool> validate);
        IValidation<T, TResult> Ignore(Func<T, bool> validate);
    }
}
