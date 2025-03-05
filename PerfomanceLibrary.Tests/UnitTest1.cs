using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PerfomanceLibrary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class PerformanceTests
        {
            [TestMethod]
            public void TestGetInfo()
            {
                var performance = new Performance(
                    "Hamlet",
                    TimeSpan.FromHours(2),
                    "A classic Shakespearean play",
                    new DateTime(2023, 10, 1, 19, 0, 0),
                    PerformanceType.Regular,
                    1.0);

                var info = performance.GetInfo();

                Assert.IsTrue(info.Contains("Hamlet"));
                Assert.IsTrue(info.Contains("A classic Shakespearean play"));
                Assert.IsTrue(info.Contains("Начало: 01.10.2023 19:00:00"));
                Assert.IsTrue(info.Contains("Продолжительность: 02:00:00"));
                Assert.IsTrue(info.Contains("Тип: Regular"));
                Assert.IsTrue(info.Contains("Коэффициент цены: 1"));
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void TestConstructor_NullTitle_ThrowsException()
            {
                var performance = new Performance(
                null,
                TimeSpan.FromHours(2),
                "Description",
                DateTime.Now,
                PerformanceType.Regular,
                1.0);
            }
        }
    }
}
