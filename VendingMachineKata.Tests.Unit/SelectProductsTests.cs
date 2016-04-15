using NUnit.Framework;

namespace VendingMachineKata.Tests.Unit
{
    public partial class VendingMachineTests
    {
        public class SelectProductsTests
        {
            [Test]
            public void ColaButtonPress_UsingCorrectChange_DispenseProduct_DisplaysThankYouThenInsertCoins_SetsTotalToZero()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.AreEqual("THANK YOU", sut.Display);
                Assert.AreEqual(Products.Cola, sut.ProductTray);
                Assert.AreEqual("INSERT COINS", sut.Display);
                Assert.AreEqual(0m, sut.Total);
            }

            [Test]
            public void CandyButtonPress_UsingCorrectChange_DispenseProduct_DisplaysThankYouThenInsertCoins_SetsTotalToZero()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Nickel);
                sut.PushCandyButton();

                Assert.AreEqual("THANK YOU", sut.Display);
                Assert.AreEqual(Products.Candy, sut.ProductTray);
                Assert.AreEqual("INSERT COINS", sut.Display);
                Assert.AreEqual(0m, sut.Total);
            }

            [Test]
            public void ChipsButtonPress_UsingCorrectChange_DispenseProduct_DisplaysThankYouThenInsertCoins_SetsTotalToZero()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.PushChipsButton();

                Assert.AreEqual("THANK YOU", sut.Display);
                Assert.AreEqual(Products.Chips, sut.ProductTray);
                Assert.AreEqual("INSERT COINS", sut.Display);
                Assert.AreEqual(0m, sut.Total);
            }

            [Test]
            public void ColaButtonPress_UsingIncorrectChange_DisplaysProductPriceThenCurrentTotal_DoesNotDispenseProduct()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.AreEqual(null, sut.ProductTray);
                Assert.AreEqual("PRICE: $1.00", sut.Display);
                Assert.AreEqual("$0.25", sut.Display);
            }

            [Test]
            public void CandyButtonPress_UsingIncorrectChange_DisplaysProductPriceThenCurrentTotal_DoesNotDispenseProduct()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.PushCandyButton();

                Assert.AreEqual(null, sut.ProductTray);
                Assert.AreEqual("PRICE: $0.65", sut.Display);
                Assert.AreEqual("$0.25", sut.Display);
            }

            [Test]
            public void ChipsButtonPress_UsingIncorrectChange_DisplaysProductPriceThenCurrentTotal_DoesNotDispenseProduct()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.PushChipsButton();

                Assert.AreEqual(null, sut.ProductTray);
                Assert.AreEqual("PRICE: $0.50", sut.Display);
                Assert.AreEqual("$0.25", sut.Display);
            }

            [Test]
            public void ColaButtonPress_WithNoMoneyInserted_DisplaysProductPriceThenInsertCoins_DoesNotDispenseProduct()
            {
                var sut = GetDefaultInstance();
                sut.PushColaButton();

                Assert.AreEqual(null, sut.ProductTray);
                Assert.AreEqual("PRICE: $1.00", sut.Display);
                Assert.AreEqual("INSERT COINS", sut.Display);
            }

            [Test]
            public void CandyButtonPress_WithNoMoneyInserted_DisplaysProductPriceThenInsertCoins_DoesNotDispenseProduct()
            {
                var sut = GetDefaultInstance();
                sut.PushCandyButton();

                Assert.AreEqual(null, sut.ProductTray);
                Assert.AreEqual("PRICE: $0.65", sut.Display);
                Assert.AreEqual("INSERT COINS", sut.Display);
            }

            [Test]
            public void ChipsButtonPress_WithNoMoneyInserted_DisplaysProductPriceThenInsertCoins_DoesNotDispenseProduct()
            {
                var sut = GetDefaultInstance();
                sut.PushChipsButton();

                Assert.AreEqual(null, sut.ProductTray);
                Assert.AreEqual("PRICE: $0.50", sut.Display);
                Assert.AreEqual("INSERT COINS", sut.Display);
            }
        }
    }
}