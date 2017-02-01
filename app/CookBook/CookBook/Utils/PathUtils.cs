using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Utils
{
    /// <summary>
    /// Class would have been used to handle image storing. As of now, this class is not used, because of problems with the image upload.
    /// </summary>
    public class PathUtils
    {
        private static String ROOTPATH = "/";
        private static String SEPARATOR_CHAR = "/";

        public static String MergePath(String path, String fileName)
        {
            String separator;
            if(path.EndsWith("/"))
            {
                separator = String.Empty;
            }
            else
            {
                separator = SEPARATOR_CHAR; 
            }
            return path + separator + fileName;
        }
    }

}
