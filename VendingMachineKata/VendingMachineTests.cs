using System;
using Xunit;

namespace VendingMachineKata
{
    public class VendingMachineTests
    {
        public class AcceptCoins
        {
            [Fact]
            public void InsertCoin_InsertNickel_SetsTotal_SetsDisplay()
            {
                var nickel = new Coin();
                var sut = new VendingMachine();
                sut.InsertCoin(nickel);
                Assert.Equal("$0.05", sut.Display);
                Assert.Equal(.05m, sut.Total);
            }
        }

    }

    public class Coin
    {
    }

    public class VendingMachine
    {
        public void InsertCoin(Coin coin)
        {
            Display = "$0.05";
            Total = .05m;
        }

        public String Display { get; set; }
        public Decimal Total { get; set; }
    }
}