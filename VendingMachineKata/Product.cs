using System;

namespace VendingMachineKata
{
    public class Product
    {
        public Product(String name, Decimal price)
        {
            Name = name;
            Price = price;
        }

        public String Name { get; }
        public Decimal Price { get; }

        #region Equal Overrides
        protected Boolean Equals(Product other)
        {
            return String.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) && Price == other.Price;
        }

        public override Boolean Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override Int32 GetHashCode()
        {
            unchecked
            {
                return (StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name)*397) ^ Price.GetHashCode();
            }
        }

        public static Boolean operator ==(Product left, Product right)
        {
            return Equals(left, right);
        }

        public static Boolean operator !=(Product left, Product right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}