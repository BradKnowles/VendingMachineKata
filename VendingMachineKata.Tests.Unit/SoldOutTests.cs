using Xunit;

namespace VendingMachineKata.Tests.Unit
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

            [Fact]
            public void ColaButtonPress_CoinsAlreadyInserted_WithColaSoldOut_DisplaySoldOutThenTotalInserted()
            {
                var sut = new VendingMachine();
                sut.UpdateProductStatus("Cola", "SOLD OUT");

                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.Equal("SOLD OUT", sut.Display);
                Assert.Equal("$1.00", sut.Display);
            }

            [Fact]
            public void CandyButtonPress_CoinsAlreadyInserted_WithCandySoldOut_DisplaySoldOutThenTotalInserted()
            {
                var sut = new VendingMachine();
                sut.UpdateProductStatus("Candy", "SOLD OUT");

                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushCandyButton();

                Assert.Equal("SOLD OUT", sut.Display);
                Assert.Equal("$1.00", sut.Display);
            }

            [Fact]
            public void ChipsButtonPress_CoinsAlreadyInserted_WithChipsSoldOut_DisplaySoldOutThenTotalInserted()
            {
                var sut = new VendingMachine();
                sut.UpdateProductStatus("Chips", "SOLD OUT");

                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushChipsButton();

                Assert.Equal("SOLD OUT", sut.Display);
                Assert.Equal("$1.00", sut.Display);
            }
        }
    }
}