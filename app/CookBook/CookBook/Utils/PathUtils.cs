using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.utils
{
    class PathUtils
    {
        private static String FILEPATH = "/";

        public static String mergedPath(String fileName)
        {
            return FILEPATH + "/" + fileName;
        }
    }
}
