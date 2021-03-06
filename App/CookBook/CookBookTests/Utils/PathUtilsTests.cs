﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CookBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Utils.Tests
{
    [TestClass()]
    public class PathUtilsTests
    {
        [TestMethod()]
        public void MergedPathTest()
        {
            String path = @"/Path/";
            String path2 = @"/Path";
            String file = @"file.txt";
            Assert.AreEqual(path + file, PathUtils.MergePath(path, file));
            Assert.AreEqual(path + file, PathUtils.MergePath(path2, file));
        }
    }
}