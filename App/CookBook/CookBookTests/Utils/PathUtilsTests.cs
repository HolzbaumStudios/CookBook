using Microsoft.VisualStudio.TestTools.UnitTesting;
using CookBook.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.utils.Tests
{
    [TestClass()]
    public class PathUtilsTests
    {
        [TestMethod()]
        public void mergedPathTest()
        {
            String path = @"/Path/";
            String path2 = @"/Path";
            String file = @"file.txt";
            Assert.AreEqual(path + file, PathUtils.MergePath(path, file));
            Assert.AreEqual(path + file, PathUtils.MergePath(path2, file));
        }
    }
}