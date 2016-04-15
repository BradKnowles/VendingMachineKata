using NUnit.Framework;

namespace VendingMachineKata.Tests.Unit
{
    public partial class VendingMachineTests
    {
        public class MakeChangeTests
        {
            [Test]
            public void ColaButtonPress_UsingMoreThanCorrectChange_DispensesProduct_ReturnsRemainingAmount()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.AreEqual("THANK YOU", sut.Display);
                Assert.AreEqual(Products.Cola, sut.ProductTray);
                Assert.AreEqual(0.50m, sut.CoinReturnTotal);
                Assert.AreEqual("INSERT COINS", sut.Display);
                Assert.AreEqual(0m, sut.Total);
            }

            [Test]
            public void CandyButtonPress_UsingMoreThanCorrectChange_DispensesProduct_ReturnsRemainingAmount()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushCandyButton();

                Assert.AreEqual("THANK YOU", sut.Display);
                Assert.AreEqual(Products.Candy, sut.ProductTray);
                Assert.AreEqual(0.35m, sut.CoinReturnTotal);
                Assert.AreEqual("INSERT COINS", sut.Display);
                Assert.AreEqual(0m, sut.Total);
            }

            [Test]
            public void ChipsButtonPress_UsingMoreThanCorrectChange_DispensesProduct_ReturnsRemainingAmount()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.PushChipsButton();

                Assert.AreEqual("THANK YOU", sut.Display);
                Assert.AreEqual(Products.Chips, sut.ProductTray);
                Assert.AreEqual(0.05m, sut.CoinReturnTotal);
                Assert.AreEqual("INSERT COINS", sut.Display);
                Assert.AreEqual(0m, sut.Total);
            }
        }
    }
}