using Microsoft.VisualStudio.TestTools.UnitTesting;
using CookBook.recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.recipes.Tests
{
    [TestClass()]
    public class StepTests
    {
        /**
         * Test the conversion of timer units.
         */
        [TestMethod()]
        public void SetTimerTest()
        {
            Step stepTest = new Step();
            stepTest.SetTimer(1, TimeUnits.Minutes);
            Assert.AreEqual(60, stepTest.Timer);
            stepTest.SetTimer(1, TimeUnits.Hours);
            Assert.AreEqual(3600, stepTest.Timer);
            stepTest.SetTimer(1, TimeUnits.Seconds);
            Assert.AreEqual(1, stepTest.Timer);
        }
    }
}