using System;

namespace VendingMachineKata
{
    public class Coin
    {
        public Decimal WeightInGrams { get; }
        public Decimal DiameterinMillimeters { get; }

        public Coin(Decimal weightInGrams, Decimal diameterinMillimeters)
        {
            WeightInGrams = weightInGrams;
            DiameterinMillimeters = diameterinMillimeters;
        }

        protected Boolean Equals(Coin other)
        {
            return WeightInGrams == other.WeightInGrams && DiameterinMillimeters == other.DiameterinMillimeters;
        }

        public override Boolean Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Coin) obj);
        }

        public override Int32 GetHashCode()
        {
            unchecked
            {
                return (WeightInGrams.GetHashCode()*397) ^ DiameterinMillimeters.GetHashCode();
            }
        }

        public static Boolean operator ==(Coin left, Coin right)
        {
            return Equals(left, right);
        }

        public static Boolean operator !=(Coin left, Coin right)
        {
            return !Equals(left, right);
        }
    }
}