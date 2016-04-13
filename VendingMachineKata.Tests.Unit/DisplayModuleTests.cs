using VendingMachineKata.Modules;
using Xunit;

namespace VendingMachineKata.Tests.Unit
{
    public class DisplayModuleTests
    {
        [Fact]
        public void DefaultState_CoinsNotInserted_DisplayInsertCoins()
        {
            var sut = new DisplayModule();

            sut.DefaultState();

            Assert.Equal("INSERT COINS", sut.ReadOut);
        }

        [Fact]
        public void DefaultState_CoinsInserted_DisplayTotalValue()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(0.15m);
            sut.DefaultState();

            Assert.Equal("$0.15", sut.ReadOut);
        }

        [Fact]
        public void PurchaseMade_CoinsNotInserted_FirstDisplayThankYouThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.PurchaseMade();

            Assert.Equal("THANK YOU", sut.ReadOut);
            Assert.Equal("INSERT COINS", sut.ReadOut);
        }

        [Fact]
        public void PurchaseMade_CoinsInserted_FirstDisplayThankYouThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(.50m);
            sut.PurchaseMade();
            sut.UpdateInsertedCoinValue(0m);

            Assert.Equal("THANK YOU", sut.ReadOut);
            Assert.Equal("INSERT COINS", sut.ReadOut);
        }

        [Fact]
        public void PurchaseMadeInsufficientFunds_CoinsNotInserted_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.InsufficientFundsForProduct(.25m);

            Assert.Equal("PRICE: $0.25", sut.ReadOut);
            Assert.Equal("INSERT COINS", sut.ReadOut);
        }

        [Fact]
        public void PurchaseMadeInsufficientFunds_CoinsInserted_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(.05m);
            sut.InsufficientFundsForProduct(.25m);

            Assert.Equal("PRICE: $0.25", sut.ReadOut);
            Assert.Equal("$0.05", sut.ReadOut);
        }

        [Fact]
        public void ProductSoldOut_CoinsNotInserted_ReadOfDisplay_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.ProductNotAvailable();

            Assert.Equal("SOLD OUT", sut.ReadOut);
            Assert.Equal("INSERT COINS", sut.ReadOut);
        }

        [Fact]
        public void ProductSoldOut_CoinsInserted_ReadOfDisplay_FirstDisplayProductPriceThenInsertCoins()
        {
            var sut = new DisplayModule();

            sut.UpdateInsertedCoinValue(.50m);
            sut.ProductNotAvailable();

            Assert.Equal("SOLD OUT", sut.ReadOut);
            Assert.Equal("$0.50", sut.ReadOut);
        }
    }
}