using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDustributor.Tests.Unit
{
    internal class BaseBankNote(int value) : IEquatable<BaseBankNote>
    {
        public virtual int Value { get; } = value;

        public override bool Equals(object? obj) => obj is BaseBankNote other && Equals(other);

        public bool Equals(BaseBankNote? other)
        {
            if (other is null)
            {
                return false;
            }

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(BaseBankNote left, BaseBankNote right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(BaseBankNote left, BaseBankNote right)
        {
            return !(left == right);
        }

        public static BaseBankNote operator +(BaseBankNote left, BaseBankNote right)
        {
            return new BaseBankNote(left.Value + right.Value);
        }
    }
}
