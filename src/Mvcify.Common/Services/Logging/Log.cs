using System;
using System.Runtime.CompilerServices;
using log4net.Core;
using Mvcify.Common.Services.Interfaces;

namespace Mvcify.Common.Services.Logging
{
    public class Log : ILog
    {
        /// <summary>
        ///     Creates a new instance of Log.
        /// </summary>
        /// <param name="log">log4net logger</param>
        public Log(log4net.ILog log)
        {
            _log4NetLog = log;
        }

        /// <summary>
        ///     Gets/ sets instance of the log4net logger to work with.
        /// </summary>
        private readonly log4net.ILog _log4NetLog;

        public virtual void Debug(object message, [CallerMemberName] string memberName = "")
        {
            _log4NetLog.Debug(message ?? memberName);
        }
        public virtual void Debug(object message, Exception exception)
        {
            _log4NetLog.Debug(message, exception);
        }

        public virtual void Debug(object message)
        {
            _log4NetLog.Debug(message);
        }

        public virtual void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log4NetLog.DebugFormat(provider, format, args);
        }

        public virtual void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _log4NetLog.DebugFormat(format, arg0, arg1, arg2);
        }

        public virtual void DebugFormat(string format, object arg0, object arg1)
        {
            _log4NetLog.DebugFormat(format, arg0, arg1);
        }

        public virtual void DebugFormat(string format, object arg0)
        {
            _log4NetLog.DebugFormat(format, arg0);
        }

        public virtual void DebugFormat(string format, params object[] args)
        {
            _log4NetLog.DebugFormat(format, args);
        }

        public virtual void Error(object message, Exception exception)
        {
            _log4NetLog.Error(message, exception);
        }

        public virtual void Error(object message)
        {
            _log4NetLog.Error(message);
        }

        public virtual void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log4NetLog.ErrorFormat(provider, format, args);
        }

        public virtual void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _log4NetLog.ErrorFormat(format, arg0, arg1, arg2);
        }

        public virtual void ErrorFormat(string format, object arg0, object arg1)
        {
            _log4NetLog.ErrorFormat(format, arg0, arg1);
        }

        public virtual void ErrorFormat(string format, object arg0)
        {
            _log4NetLog.ErrorFormat(format, arg0);
        }

        public virtual void ErrorFormat(string format, params object[] args)
        {
            _log4NetLog.ErrorFormat(format, args);
        }

        public virtual void Fatal(object message, Exception exception)
        {
            _log4NetLog.Fatal(message, exception);
        }

        public virtual void Fatal(object message)
        {
            _log4NetLog.Fatal(message);
        }

        public virtual void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log4NetLog.FatalFormat(provider, format, args);
        }

        public virtual void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _log4NetLog.FatalFormat(format, arg0, arg1, arg2);
        }

        public virtual void FatalFormat(string format, object arg0, object arg1)
        {
            _log4NetLog.FatalFormat(format, arg0, arg1);
        }

        public virtual void FatalFormat(string format, object arg0)
        {
            _log4NetLog.FatalFormat(format, arg0);
        }

        public virtual void FatalFormat(string format, params object[] args)
        {
            _log4NetLog.FatalFormat(format, args);
        }

        public virtual void Info(object message, Exception exception)
        {
            _log4NetLog.Info(message, exception);
        }

        public virtual void Info(object message)
        {
            _log4NetLog.Info(message);
        }

        public virtual void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log4NetLog.InfoFormat(provider, format, args);
        }

        public virtual void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _log4NetLog.InfoFormat(format, arg0, arg1, arg2);
        }

        public virtual void InfoFormat(string format, object arg0, object arg1)
        {
            _log4NetLog.InfoFormat(format, arg0, arg1);
        }

        public virtual void InfoFormat(string format, object arg0)
        {
            _log4NetLog.InfoFormat(format, arg0);
        }

        public virtual void InfoFormat(string format, params object[] args)
        {
            _log4NetLog.InfoFormat(format, args);
        }

        public bool IsDebugEnabled
        {
            get { return _log4NetLog.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return _log4NetLog.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return _log4NetLog.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return _log4NetLog.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return _log4NetLog.IsWarnEnabled; }
        }

        public virtual void Warn(object message, Exception exception)
        {
            _log4NetLog.Warn(message, exception);
        }

        public virtual void Warn(object message)
        {
            _log4NetLog.Warn(message);
        }

        public virtual void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log4NetLog.WarnFormat(provider, format, args);
        }

        public virtual void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _log4NetLog.WarnFormat(format, arg0, arg1, arg2);
        }

        public virtual void WarnFormat(string format, object arg0, object arg1)
        {
            _log4NetLog.WarnFormat(format, arg0, arg1);
        }

        public virtual void WarnFormat(string format, object arg0)
        {
            _log4NetLog.WarnFormat(format, arg0);
        }

        public virtual void WarnFormat(string format, params object[] args)
        {
            _log4NetLog.WarnFormat(format, args);
        }

        ILogger ILoggerWrapper.Logger
        {
            get { return _log4NetLog.Logger; }
        }
    }
}