using Exzamen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<double, double> money = new Dictionary<double, double>();
            for (int i = 0; i < 10; i++)
                money.Add(i, i);
            double maxValue = Program.SeachMaxValue(money);
            Assert.AreEqual(maxValue, 9);
        }
        [TestMethod]
        public void TestMethod2()
        {
            for (int i = 700000; i < 1000000; i++)
            {
                double percent = Program.GetPercent(i);
                Assert.AreEqual(percent, 20);
            }

        }
        [TestMethod]
        public void TestMethod3()
        {
            double percent = Program.GetPercent(40000);
            Assert.AreEqual(percent, 1);
        }
        [TestMethod]
        public void TestMethod4()
        {
            double percent = Program.GetPercent(400000);
            Assert.AreEqual(percent, 9);
        }
        [TestMethod]
        public void TestMethod5()
        {
            double percent = Program.GetPercent(245759);
            Assert.AreEqual(percent, 5);
        }
    }
}