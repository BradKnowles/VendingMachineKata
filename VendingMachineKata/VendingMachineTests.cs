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

            [Fact]
            public void InsertCoin_InsertPenny_DoesNotSetTotal_SendsToCoinReturn()
            {
                var penny = new Coin();
                var sut = new VendingMachine();
                sut.InsertCoin(penny);
                Assert.Equal("$0.00", sut.Display);
                Assert.Equal(.00m, sut.Total);
                Assert.Equal(penny, sut.CoinReturn);
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
        public Coin CoinReturn { get; set; }
    }
}