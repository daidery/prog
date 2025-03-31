using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PerfomanceLibrary;

namespace PerfomanceLibrary.Tests
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        public void Performance_GetInfo_ReturnsCorrectInformation()
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
        public void Performance_Constructor_NullTitle_ThrowsException()
        {
            var performance = new Performance(
                null,
                TimeSpan.FromHours(2),
                "Description",
                DateTime.Now,
                PerformanceType.Regular,
                1.0);
        }

        [TestMethod]
        public void Performance_EndDateTime_CalculatedCorrectly()
        {
            var start = new DateTime(2023, 10, 1, 19, 0, 0);
            var duration = TimeSpan.FromHours(2.5);
            var performance = new Performance(
                "Test",
                duration,
                "Test",
                start,
                PerformanceType.Regular,
                1.0);

            Assert.AreEqual(start.Add(duration), performance.EndDateTime);
        }
    }

    [TestClass]
    public class OperaTests
    {
        [TestMethod]
        public void Opera_GetInfo_IncludesComposerAndLibrettist()
        {
            var opera = new Opera(
                "La Traviata",
                TimeSpan.FromHours(2.5),
                "Opera in three acts",
                new DateTime(2023, 7, 1, 18, 30, 0),
                PerformanceType.Regular,
                1.2,
                "Giuseppe Verdi",
                "Francesco Maria Piave");

            var info = opera.GetInfo();

            Assert.IsTrue(info.Contains("Композитор: Giuseppe Verdi"));
            Assert.IsTrue(info.Contains("Автор либретто: Francesco Maria Piave"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Opera_Constructor_NullComposer_ThrowsException()
        {
            var opera = new Opera(
                "Title",
                TimeSpan.FromHours(1),
                "Desc",
                DateTime.Now,
                PerformanceType.Regular,
                1.0,
                null,
                "Librettist");
        }
    }

    [TestClass]
    public class BalletTests
    {
        [TestMethod]
        public void Ballet_GetInfo_IncludesComposerAndChoreographer()
        {
            var ballet = new Ballet(
                "Swan Lake",
                TimeSpan.FromHours(3),
                "Classical ballet in four acts",
                new DateTime(2023, 7, 15, 19, 0, 0),
                PerformanceType.Premiere,
                1.8,
                "Pyotr Ilyich Tchaikovsky",
                "Marius Petipa");

            var info = ballet.GetInfo();

            Assert.IsTrue(info.Contains("Композитор: Pyotr Ilyich Tchaikovsky"));
            Assert.IsTrue(info.Contains("Хореограф: Marius Petipa"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ballet_Constructor_NullChoreographer_ThrowsException()
        {
            var ballet = new Ballet(
                "Title",
                TimeSpan.FromHours(1),
                "Desc",
                DateTime.Now,
                PerformanceType.Regular,
                1.0,
                "Composer",
                null);
        }
    }

    [TestClass]
    public class DramaTests
    {
        [TestMethod]
        public void Drama_GetInfo_IncludesPlaywright()
        {
            var drama = new Drama(
                "The Cherry Orchard",
                TimeSpan.FromHours(2),
                "Drama in four acts",
                new DateTime(2023, 8, 1, 18, 30, 0),
                PerformanceType.LastSeason,
                1.0,
                "Anton Chekhov");

            var info = drama.GetInfo();

            Assert.IsTrue(info.Contains("Автор пьесы: Anton Chekhov"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Drama_Constructor_NullPlaywright_ThrowsException()
        {
            var drama = new Drama(
                "Title",
                TimeSpan.FromHours(1),
                "Desc",
                DateTime.Now,
                PerformanceType.Regular,
                1.0,
                null);
        }
    }

    [TestClass]
    public class InheritanceTests
    {
        [TestMethod]
        public void DerivedClasses_AreActuallyPerformance()
        {
            var opera = new Opera(
                "Opera",
                TimeSpan.FromHours(1),
                "Desc",
                DateTime.Now,
                PerformanceType.Regular,
                1.0,
                "Composer",
                "Librettist");

            var ballet = new Ballet(
                "Ballet",
                TimeSpan.FromHours(1),
                "Desc",
                DateTime.Now,
                PerformanceType.Regular,
                1.0,
                "Composer",
                "Choreographer");

            var drama = new Drama(
                "Drama",
                TimeSpan.FromHours(1),
                "Desc",
                DateTime.Now,
                PerformanceType.Regular,
                1.0,
                "Playwright");

            Assert.IsInstanceOfType(opera, typeof(Performance));
            Assert.IsInstanceOfType(ballet, typeof(Performance));
            Assert.IsInstanceOfType(drama, typeof(Performance));
        }
    }
}
