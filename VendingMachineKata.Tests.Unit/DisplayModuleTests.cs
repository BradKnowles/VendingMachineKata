using VendingMachineKata.Modules;
using Xunit;

namespace VendingMachineKata.Tests.Unit
{
    public class DisplayModuleTests
    {
        [Fact]
        public void DefaultState_NoCoins_Inserted_DisplayInsertCoins()
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
        public void PurchaseMade_ReadOfDisplay_FirstDisplayThankYouThenInsertCoins()
        {
            var sut = new DisplayModule();
            sut.PurchaseMade();
            Assert.Equal("THANK YOU", sut.ReadOut);
            Assert.Equal("INSERT COINS", sut.ReadOut);

        }
    }
}