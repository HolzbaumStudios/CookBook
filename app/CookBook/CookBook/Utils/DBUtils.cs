﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.utils
{
    static class DBUtils
    {
        public static string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationSettings.AppSettings property 
            return "Data Source=(blancos.ch);Initial Catalog=CookBook;"
                + "Integrated Security=SSPI;";
        }
    }
}
