using VendingMachineKata.Modules;

namespace VendingMachineKata.Tests.Unit
{
    public partial class VendingMachineTests
    {
        public static VendingMachine GetDefaultInstance()
        {
            return new VendingMachine(new DisplayModule());
        }
        private static class Coins {
            // US Coin Information - https://www.usmint.gov/about_the_mint/?action=coin_specifications
            // Candian Coin Information - http://www.mint.ca/store/mint/about-the-mint/canadian-circulation-1100028
            public static Coin Penny => new Coin(2.5m, 19.05m);
            public static Coin Nickel => new Coin(5m, 21.21m);
            public static Coin Dime => new Coin(2.268m, 17.91m);
            public static Coin Quarter => new Coin(5.670m, 24.26m);
            public static Coin HalfDollar => new Coin(11.340m, 30.61m);
            public static Coin PresidentialDollar => new Coin(8.1m, 26.49m);
            public static Coin CanadianPenny => new Coin(2.35m, 19.05m);
            public static Coin CanadianNickel => new Coin(3.95m, 21.2m);
            public static Coin CanadianDime => new Coin(1.75m, 18.03m);
            public static Coin CanadianQuarter => new Coin(4.4m, 23.88m);
            public static Coin CanadianHalfDollar => new Coin(6.9m, 27.13m);
            public static Coin CanadianDollar => new Coin(6.27m, 26.5m);
            public static Coin CanadianTwoDollar => new Coin(6.92m, 28m);
        }

        private static class Products
        {
            public static Product Cola => new Product("Cola", 1m);
            public static Product Candy => new Product("Candy", 0.65m);
            public static Product Chips => new Product("Chips", 0.50m);
        }
    }
}