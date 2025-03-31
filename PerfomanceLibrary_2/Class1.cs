using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceLibrary
{
    public enum PerformanceType
    {
        Regular,
        Premiere,
        LastSeason
    }
    public class Performance
    {
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
    }
    public class Opera : Performance
    {
        public string Composer { get; }
        public string Librettist { get; }
        public Opera(string title, TimeSpan duration, string description, DateTime startDateTime,
                    PerformanceType type, double priceCoefficient, string composer, string librettist)
            : base(title, duration, description, startDateTime, type, priceCoefficient)
        {
            Composer = composer ?? throw new ArgumentNullException(nameof(composer));
            Librettist = librettist ?? throw new ArgumentNullException(nameof(librettist));
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $", Композитор: {Composer}, Автор либретто: {Librettist}";
        }
    }
    public class Ballet : Performance
    {
        public string Composer { get; }
        public string Choreographer { get; }
        public Ballet(string title, TimeSpan duration, string description, DateTime startDateTime,
                     PerformanceType type, double priceCoefficient, string composer, string choreographer)
            : base(title, duration, description, startDateTime, type, priceCoefficient)
        {
            Composer = composer ?? throw new ArgumentNullException(nameof(composer));
            Choreographer = choreographer ?? throw new ArgumentNullException(nameof(choreographer));
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $", Композитор: {Composer}, Хореограф: {Choreographer}";
        }
    }
    public class Drama : Performance
    {
        public string Playwright { get; }
        public Drama(string title, TimeSpan duration, string description, DateTime startDateTime,
                    PerformanceType type, double priceCoefficient, string playwright)
            : base(title, duration, description, startDateTime, type, priceCoefficient)
        {
            Playwright = playwright ?? throw new ArgumentNullException(nameof(playwright));
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $", Автор пьесы: {Playwright}";
        }
    }
}
