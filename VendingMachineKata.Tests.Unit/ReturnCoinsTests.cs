using System.Linq;
using NUnit.Framework;

namespace VendingMachineKata.Tests.Unit
{
    public partial class VendingMachineTests
    {
        public class ReturnCoinsTests
        {
            [Test]
            public void ReturnCoinPressed_WhenCustomerInsertedCoins_ReturnsCoins_DisplaysInsertCoins()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Dime);

                sut.ReturnCoins();

                Assert.That(sut.CoinReturnSlot, Has.Exactly(1).EqualTo(Coins.Quarter));
                Assert.That(sut.CoinReturnSlot, Has.Exactly(1).EqualTo(Coins.Nickel));
                Assert.That(sut.CoinReturnSlot, Has.Exactly(1).EqualTo(Coins.Dime));
                Assert.AreEqual("INSERT COINS", sut.Display);
            }

            [Test]
            public void ReturnCoinPressed_WhenCustomerInsertsMultipleSimiliarCoins_ReturnsCorrectNumberAndTypeOfCoins_DisplaysInsertCoins()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);

                sut.ReturnCoins();

                Assert.That(sut.CoinReturnSlot, Has.Exactly(2).EqualTo(Coins.Quarter));
                Assert.That(sut.CoinReturnSlot, Has.Exactly(3).EqualTo(Coins.Nickel));
                Assert.That(sut.CoinReturnSlot, Has.Exactly(2).EqualTo(Coins.Dime));
                Assert.That(sut.CoinReturnSlot.Count(), Is.EqualTo(7));
                Assert.AreEqual("INSERT COINS", sut.Display);
            }
        }
    }
}