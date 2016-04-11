using Xunit;

namespace VendingMachineKata
{
    public partial class VendingMachineTests
    {
        public class SoldOutTests
        {
            [Fact]
            public void ColaButtonPress_NoCoinsInserted_WithColaSoldOut_DisplaySoldOutThenInsertCoins()
            {
                var sut = new VendingMachine();
                sut.UpdateProductStatus("Cola", "SOLD OUT");

                sut.PushColaButton();

                Assert.Equal("SOLD OUT", sut.Display);
                Assert.Equal("INSERT COINS", sut.Display);
            }

            [Fact]
            public void CandyButtonPress_NoCoinsInserted_WithCandySoldOut_DisplaySoldOutThenInsertCoins()
            {
                var sut = new VendingMachine();
                sut.UpdateProductStatus("Candy", "SOLD OUT");

                sut.PushCandyButton();

                Assert.Equal("SOLD OUT", sut.Display);
                Assert.Equal("INSERT COINS", sut.Display);
            }

            [Fact]
            public void ChipsButtonPress_NoCoinsInserted_WithChipsSoldOut_DisplaySoldOutThenInsertCoins()
            {
                var sut = new VendingMachine();
                sut.UpdateProductStatus("Chips", "SOLD OUT");

                sut.PushChipsButton();

                Assert.Equal("SOLD OUT", sut.Display);
                Assert.Equal("INSERT COINS", sut.Display);
            }
        }
    }
}