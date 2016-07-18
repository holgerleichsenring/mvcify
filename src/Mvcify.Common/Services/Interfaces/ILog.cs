using System.Runtime.CompilerServices;

namespace Mvcify.Common.Services.Interfaces
{
    /// <summary>
    ///     This interface hides log4net for all classes that use logging.
    /// </summary>
    public interface ILog : log4net.ILog
    {
        void Debug(object message = null, [CallerMemberName] string memberName = "");
    }
}