using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public struct ZPower
    {
        private double _base;
        private int _exponent;

        public ZPower(double baseValue, int exponentValue)
        {
            if (baseValue == 0 && exponentValue < 0)
                throw new ArgumentException("Base cannot be zero when exponent is negative.");

            _base = baseValue;
            _exponent = exponentValue;
        }

        public double Base
        {
            get => _base;
            set
            {
                if (value == 0 && _exponent < 0)
                    throw new ArgumentException("Base cannot be zero when exponent is negative.");
                _base = value;
            }
        }

        public int Exponent
        {
            get => _exponent;
            set => _exponent = value;
        }

        public double Value => Math.Pow(_base, _exponent);

        public override string ToString()
        {
            return $"{_base.ToString("G5", CultureInfo.InvariantCulture)}E{_exponent}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ZPower other)
            {
                return Math.Abs(this.Value - other.Value) < 1e-13;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static ZPower operator *(ZPower a, ZPower b)
        {
            if (Math.Abs(a.Base - b.Base) > 1e-13)
                throw new InvalidOperationException("Cannot multiply powers with different bases.");
            return new ZPower(a.Base, a.Exponent + b.Exponent);
        }

        public static ZPower operator /(ZPower a, ZPower b)
        {
            if (Math.Abs(a.Base - b.Base) > 1e-13)
                throw new InvalidOperationException("Cannot divide powers with different bases.");
            return new ZPower(a.Base, a.Exponent - b.Exponent);
        }
    }
}


