using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PerfomanceLibrary;
using static PerfomanceLibrary.Performance;

namespace PerformanceLibrary.Tests
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        public void PerformanceComparison_ShouldOrderByDateTime()
        {
            var earlier = new Performance("Ранний", TimeSpan.FromHours(2), "Описание",
                new DateTime(2023, 5, 1, 18, 0, 0), PerformanceType.Regular, 1.0);

            var later = new Performance("Поздний", TimeSpan.FromHours(2), "Описание",
                new DateTime(2023, 5, 1, 20, 0, 0), PerformanceType.Regular, 1.0);

            Assert.IsTrue(earlier.CompareTo(later) < 0);
            Assert.IsTrue(later.CompareTo(earlier) > 0);
        }

        [TestMethod]
        public void RepertoireCreation_ShouldFilterByMonthAndYear()
        {
            var performances = new List<Performance>
            {
                new Performance("Спектакль 1", TimeSpan.FromHours(2), "Описание",
                    new DateTime(2023, 5, 1), PerformanceType.Regular, 1.0),
                new Performance("Спектакль 2", TimeSpan.FromHours(2), "Описание",
                    new DateTime(2023, 5, 15), PerformanceType.Premiere, 1.5),
                new Performance("Спектакль 3", TimeSpan.FromHours(2), "Описание",
                    new DateTime(2023, 6, 1), PerformanceType.LastSeason, 0.8),
                new Performance("Спектакль 1", TimeSpan.FromHours(2), "Описание",
                    new DateTime(2023, 5, 1), PerformanceType.Regular, 1.0)
            };

            var repertoire = new Repertoire(Month.May, 2023, performances);

            Assert.AreEqual(2, repertoire.PerformanceCount);
        }

        [TestMethod]
        public void RepertoireEnumeration_ShouldBeInChronologicalOrder()
        {
            var performances = new List<Performance>
            {
                new Performance("Спектакль 2", TimeSpan.FromHours(2), "Описание",
                    new DateTime(2023, 5, 15), PerformanceType.Premiere, 1.5),
                new Performance("Спектакль 1", TimeSpan.FromHours(2), "Описание",
                    new DateTime(2023, 5, 1), PerformanceType.Regular, 1.0)
            };

            var repertoire = new Repertoire(Month.May, 2023, performances);

            using (var enumerator = repertoire.GetEnumerator())
            {
                enumerator.MoveNext();
                Assert.AreEqual("Спектакль 1", enumerator.Current.Title);
                enumerator.MoveNext();
                Assert.AreEqual("Спектакль 2", enumerator.Current.Title);
            }
        }
    }
}