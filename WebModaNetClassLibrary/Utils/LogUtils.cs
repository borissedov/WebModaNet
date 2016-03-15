using log4net;
using System;

namespace EW.WebModaNetClassLibrary.Utils
{
	public static class LogUtils
	{
		private static ILog Logger;

		static LogUtils()
		{
			LogUtils.Logger = LogManager.GetLogger(typeof(LogUtils));
		}

		public static void Debug(object message)
		{
			LogUtils.Debug(message, null);
		}

		public static void Debug(object message, Exception exception)
		{
			if (LogUtils.Logger.IsDebugEnabled)
			{
				if (exception != null)
				{
					LogUtils.Logger.Debug(message, exception);
					return;
				}
				LogUtils.Logger.Debug(message);
			}
		}

		public static void Error(object message)
		{
			LogUtils.Error(message, null);
		}

		public static void Error(object message, Exception exception)
		{
			if (LogUtils.Logger.IsErrorEnabled)
			{
				if (exception != null)
				{
					LogUtils.Logger.Error(message, exception);
					return;
				}
				LogUtils.Logger.Error(message);
			}
		}

		public static void Fatal(object message)
		{
			LogUtils.Fatal(message, null);
		}

		public static void Fatal(object message, Exception exception)
		{
			if (LogUtils.Logger.IsFatalEnabled)
			{
				if (exception != null)
				{
					LogUtils.Logger.Fatal(message, exception);
					return;
				}
				LogUtils.Logger.Fatal(message);
			}
		}

		public static void Info(object message)
		{
			LogUtils.Info(message, null);
		}

		public static void Info(object message, Exception exception)
		{
			if (LogUtils.Logger.IsInfoEnabled)
			{
				if (exception != null)
				{
					LogUtils.Logger.Info(message, exception);
					return;
				}
				LogUtils.Logger.Info(message);
			}
		}

		public static void Warn(object message)
		{
			LogUtils.Warn(message, null);
		}

		public static void Warn(object message, Exception exception)
		{
			if (LogUtils.Logger.IsWarnEnabled)
			{
				if (exception != null)
				{
					LogUtils.Logger.Warn(message, exception);
					return;
				}
				LogUtils.Logger.Warn(message);
			}
		}
	}
}