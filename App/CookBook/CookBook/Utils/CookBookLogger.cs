using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace CookBook.Utils
{
    class CookBookLogger
    {
        /// <summary>
        /// Defines which logger should be used, depending on the configuration mode.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public void WriteLog(String tag, String message, LoggerType type)
        {
#if DEBUG
            LogOnWindowsConsole(tag, message, type);
#else
            LogOnAndroid(tag, message, type);
#endif
        }

        /// <summary>
        /// Logs messages on the default android logger.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        private void LogOnAndroid(String tag, String message, LoggerType type)
        {
            switch(type)
            {
                case LoggerType.Debug: Log.Debug(tag, message);
                    break;
                case LoggerType.Error: Log.Error(tag, message);
                    break;
                case LoggerType.Info: Log.Info(tag, message);
                    break;
                case LoggerType.Warn: Log.Warn(tag, message);
                    break;
            }
        }


        /// <summary>
        /// Logs the on windows console.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        private void LogOnWindowsConsole(String tag, String message, LoggerType type)
        {
            Console.WriteLine("{0}: {1}, {2}", type.ToString().ToUpper(), message, tag);
        }
    }

    public enum LoggerType { Warn, Debug, Error, Info};
}