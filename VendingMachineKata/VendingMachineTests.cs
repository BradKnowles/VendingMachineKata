using System;
using Xunit;

namespace VendingMachineKata
{
    public class VendingMachineTests
    {
        public class AcceptCoins
        {
            [Fact]
            public void InsertCoin_InsertNickel_UpdatesTotal_ReturnsTotalForDisplay()
            {
                var validCoin = new Coin();
                var sut = new VendingMachine();
                var results = sut.InsertCoin(validCoin);

                Assert.Equal("$0.05", results);
            }
        }

    }

    public class Coin
    {
    }

    public class VendingMachine
    {
        public String InsertCoin(Coin coin)
        {
            return "$0.05";
        }
    }
}