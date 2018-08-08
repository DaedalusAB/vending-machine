using System;

namespace VendingMachine
{
    public class Credit
    {
        public int Value { get; }

        public Credit(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Credit otherCredit && otherCredit.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
