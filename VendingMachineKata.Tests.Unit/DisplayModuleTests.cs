using NUnit.Framework;
using VendingMachineKata.Modules;

namespace VendingMachineKata.Tests.Unit
{
    public class DisplayModuleTests
    {
        [Test]
        public void DefaultState_CoinsNotInserted_DisplayInsertCoins()
        {
            var sut = new DisplayModule();

            sut.DefaultState();

            Assert.AreEqual("INSERT COINS", sut.ReadOut);
        }

        [Test]
        public void DefaultState_CoinsInserted_DisplayTotalValue()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(0.15m);
            sut.DefaultState();

            Assert.AreEqual("$0.15", sut.ReadOut);
        }

        [Test]
        public void PurchaseMade_CoinsNotInserted_FirstDisplayThankYouThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.PurchaseMade();

            Assert.AreEqual("THANK YOU", sut.ReadOut);
            Assert.AreEqual("INSERT COINS", sut.ReadOut);
        }

        [Test]
        public void PurchaseMade_CoinsInserted_FirstDisplayThankYouThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(.50m);
            sut.PurchaseMade();
            sut.UpdateInsertedCoinValue(0m);

            Assert.AreEqual("THANK YOU", sut.ReadOut);
            Assert.AreEqual("INSERT COINS", sut.ReadOut);
        }

        [Test]
        public void PurchaseMadeInsufficientFunds_CoinsNotInserted_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.InsufficientFundsForProduct(.25m);

            Assert.AreEqual("PRICE: $0.25", sut.ReadOut);
            Assert.AreEqual("INSERT COINS", sut.ReadOut);
        }

        [Test]
        public void PurchaseMadeInsufficientFunds_CoinsInserted_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(.05m);
            sut.InsufficientFundsForProduct(.25m);

            Assert.AreEqual("PRICE: $0.25", sut.ReadOut);
            Assert.AreEqual("$0.05", sut.ReadOut);
        }

        [Test]
        public void ProductSoldOut_CoinsNotInserted_ReadOfDisplay_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.ProductNotAvailable();

            Assert.AreEqual("SOLD OUT", sut.ReadOut);
            Assert.AreEqual("INSERT COINS", sut.ReadOut);
        }

        [Test]
        public void ProductSoldOut_CoinsInserted_ReadOfDisplay_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(.50m);
            sut.ProductNotAvailable();

            Assert.AreEqual("SOLD OUT", sut.ReadOut);
            Assert.AreEqual("$0.50", sut.ReadOut);
        }
    }
}