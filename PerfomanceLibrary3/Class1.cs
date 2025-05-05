using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceLibrary
{
    public class Performance : IComparable<Performance>, IEquatable<Performance>
    {
        public enum PerformanceType
        {
            Regular,
            Premiere,
            LastSeason
        }

        private string _title;
        private TimeSpan _duration;
        private string _description;
        private DateTime _startDateTime;
        private PerformanceType _type;
        private double _priceCoefficient;
        public string Title => _title;
        public TimeSpan Duration => _duration;
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        public DateTime StartDateTime => _startDateTime;
        public DateTime EndDateTime => _startDateTime.Add(_duration);
        public PerformanceType Type => _type;
        public double PriceCoefficient => _priceCoefficient;
        public Performance(string title, TimeSpan duration, string description, DateTime startDateTime, PerformanceType type, double priceCoefficient)
        {
            _title = title ?? throw new ArgumentNullException(nameof(title));
            _duration = duration;
            _description = description ?? string.Empty;
            _startDateTime = startDateTime;
            _type = type;
            _priceCoefficient = priceCoefficient;
        }
        public virtual string GetInfo()
        {
            return $"{Title} - {Description}, Начало: {StartDateTime}, Продолжительность: {Duration}, Тип: {Type}, Коэффициент цены: {PriceCoefficient}";
        }

        public int CompareTo(Performance other)
        {
            if (other == null) return 1;
            return this._startDateTime.CompareTo(other._startDateTime);
        }

        public bool Equals(Performance other)
        {
            if (other == null) return false;
            return this._title == other._title &&
                   this._startDateTime == other._startDateTime &&
                   this._duration == other._duration;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Performance);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (_title?.GetHashCode() ?? 0);
                hash = hash * 23 + _startDateTime.GetHashCode();
                hash = hash * 23 + _duration.GetHashCode();
                return hash;
            }
        }
    }

    public class Repertoire : IEnumerable<Performance>
    {
        private List<Performance> _performances;

        public Month Month { get; }
        public int Year { get; }
        public int PerformanceCount => _performances.Count;

        public Repertoire(Month month, int year, IEnumerable<Performance> performances)
        {
            Month = month;
            Year = year;

            _performances = performances
                .Where(p => p.StartDateTime.Month == (int)month && p.StartDateTime.Year == year)
                .Distinct()
                .OrderBy(p => p.StartDateTime)
                .ToList();
        }

        public IEnumerator<Performance> GetEnumerator()
        {
            return _performances.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}