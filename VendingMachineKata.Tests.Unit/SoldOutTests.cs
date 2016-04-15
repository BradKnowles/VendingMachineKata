using NUnit.Framework;

namespace VendingMachineKata.Tests.Unit
{
    public partial class VendingMachineTests
    {
        public class SoldOutTests
        {
            [Test]
            public void ColaButtonPress_NoCoinsInserted_WithColaSoldOut_DisplaySoldOutThenInsertCoins()
            {
                var sut = GetDefaultInstance();
                sut.UpdateProductStatus("Cola", "SOLD OUT");

                sut.PushColaButton();

                Assert.AreEqual("SOLD OUT", sut.Display);
                Assert.AreEqual("INSERT COINS", sut.Display);
            }

            [Test]
            public void CandyButtonPress_NoCoinsInserted_WithCandySoldOut_DisplaySoldOutThenInsertCoins()
            {
                var sut = GetDefaultInstance();
                sut.UpdateProductStatus("Candy", "SOLD OUT");

                sut.PushCandyButton();

                Assert.AreEqual("SOLD OUT", sut.Display);
                Assert.AreEqual("INSERT COINS", sut.Display);
            }

            [Test]
            public void ChipsButtonPress_NoCoinsInserted_WithChipsSoldOut_DisplaySoldOutThenInsertCoins()
            {
                var sut = GetDefaultInstance();
                sut.UpdateProductStatus("Chips", "SOLD OUT");

                sut.PushChipsButton();

                Assert.AreEqual("SOLD OUT", sut.Display);
                Assert.AreEqual("INSERT COINS", sut.Display);
            }

            [Test]
            public void ColaButtonPress_CoinsAlreadyInserted_WithColaSoldOut_DisplaySoldOutThenTotalInserted()
            {
                var sut = GetDefaultInstance();
                sut.UpdateProductStatus("Cola", "SOLD OUT");

                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.AreEqual("SOLD OUT", sut.Display);
                Assert.AreEqual("$1.00", sut.Display);
            }

            [Test]
            public void CandyButtonPress_CoinsAlreadyInserted_WithCandySoldOut_DisplaySoldOutThenTotalInserted()
            {
                var sut = GetDefaultInstance();
                sut.UpdateProductStatus("Candy", "SOLD OUT");

                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushCandyButton();

                Assert.AreEqual("SOLD OUT", sut.Display);
                Assert.AreEqual("$1.00", sut.Display);
            }

            [Test]
            public void ChipsButtonPress_CoinsAlreadyInserted_WithChipsSoldOut_DisplaySoldOutThenTotalInserted()
            {
                var sut = GetDefaultInstance();
                sut.UpdateProductStatus("Chips", "SOLD OUT");

                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushChipsButton();

                Assert.AreEqual("SOLD OUT", sut.Display);
                Assert.AreEqual("$1.00", sut.Display);
            }
        }
    }
}