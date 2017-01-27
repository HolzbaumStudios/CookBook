using CookBook.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.utils
{
    public static class DBUtils
    {
        private static readonly String LOGGER_TAG = "CookBook.utils.DBUtils";
        private static CookBookLogger logger = new CookBookLogger(LOGGER_TAG);

        public static String GetConnectionString()
        {
            //TODO - SECURE Connection
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationSettings.AppSettings property 
            return "server=blancos.ch;" +
                "database=nicoleu1_DBCookBook;" +
                "user id=nicoleu1_DBCookB; " +
                "pwd=WokuDasEi;" +
                "Connect Timeout=30;"; 
        }

        /// <summary>
        /// Converts MySqlDataReader Result to String.
        /// </summary>
        /// <param name="dbObject">The database object.</param>
        /// <returns></returns>
        public static String AsString(Object dbObject)
        {
            String value = String.Empty;
            if(dbObject != null && dbObject != DBNull.Value)
            {
                try
                {
                    value = dbObject.ToString();
                }
                catch(Exception ex)
                {
                    LogExceptions(ex);   
                    
                }
            }
            return value;
        }

        /// <summary>
        /// Converts MySqlDataReader Result to Integer.
        /// </summary>
        /// <param name="dbObject">The database object.</param>
        /// <returns></returns>
        public static int AsInteger(Object dbObject)
        {
            int value = 0;
            if (dbObject != null && dbObject != DBNull.Value)
            {
                try
                {
                    value = Convert.ToInt32(dbObject);
                }
                catch (Exception ex)
                {
                    LogExceptions(ex);
                }
            }
            return value;
        }

        /// <summary>
        /// Logs the Conversion exceptions.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private static void LogExceptions(Exception ex)
        {
            if (ex.GetType() == typeof(ArgumentNullException))
            {
               logger.WriteLog("The provided value is null: " + ex, LoggerType.Error);
            }
            else if (ex.GetType() == typeof(FormatException))
            {
                logger.WriteLog("Error while converting values: " + ex, LoggerType.Error);
            }
            else if (ex.GetType() == typeof(OverflowException))
            {
                logger.WriteLog("Overflow exception while converting:" + ex, LoggerType.Error);
            }
        }
    }
}
