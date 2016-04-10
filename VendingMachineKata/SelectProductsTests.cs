using Xunit;

namespace VendingMachineKata
{
    public partial class VendingMachineTests
    {
        public class SelectProductsTests
        {
            [Fact]
            public void ColaButtonPress_UsingCorrectChange_DispenseProduct_DisplaysThankYouThenInsertCoins_SetsTotalToZero()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.Equal("THANK YOU", sut.Display);
                Assert.Equal(Products.Cola, sut.ProductTray);
                Assert.Equal("INSERT COINS", sut.Display);
                Assert.Equal(0m, sut.Total);
            }

            [Fact]
            public void CandyButtonPress_UsingCorrectChange_DispenseProduct_DisplaysThankYouThenInsertCoins_SetsTotalToZero()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Nickel);
                sut.PushCandyButton();

                Assert.Equal("THANK YOU", sut.Display);
                Assert.Equal(Products.Candy, sut.ProductTray);
                Assert.Equal("INSERT COINS", sut.Display);
                Assert.Equal(0m, sut.Total);
            }

            [Fact]
            public void ChipsButtonPress_UsingCorrectChange_DispenseProduct_DisplaysThankYouThenInsertCoins_SetsTotalToZero()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.PushChipsButton();

                Assert.Equal("THANK YOU", sut.Display);
                Assert.Equal(Products.Chips, sut.ProductTray);
                Assert.Equal("INSERT COINS", sut.Display);
                Assert.Equal(0m, sut.Total);
            }

            [Fact]
            public void ColaButtonPress_UsingIncorrectChange_DisplaysProductPriceThenCurrentTotal_DoesNotDispenseProduct()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.Equal(null, sut.ProductTray);
                Assert.Equal("PRICE: $1.00", sut.Display);
                Assert.Equal("$0.25", sut.Display);
            }

            [Fact]
            public void CandyButtonPress_UsingIncorrectChange_DisplaysProductPriceThenCurrentTotal_DoesNotDispenseProduct()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.PushCandyButton();

                Assert.Equal(null, sut.ProductTray);
                Assert.Equal("PRICE: $0.65", sut.Display);
                Assert.Equal("$0.25", sut.Display);
            }

            [Fact]
            public void ChipsButtonPress_UsingIncorrectChange_DisplaysProductPriceThenCurrentTotal_DoesNotDispenseProduct()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.PushChipsButton();

                Assert.Equal(null, sut.ProductTray);
                Assert.Equal("PRICE: $0.50", sut.Display);
                Assert.Equal("$0.25", sut.Display);
            }

            [Fact]
            public void ColaButtonPress_WithNoMoneyInserted_DisplaysProductPriceThenInsertCoins_DoesNotDispenseProduct()
            {
                var sut = new VendingMachine();
                sut.PushColaButton();

                Assert.Equal(null, sut.ProductTray);
                Assert.Equal("PRICE: $1.00", sut.Display);
                Assert.Equal("INSERT COINS", sut.Display);
            }

            [Fact]
            public void CandyButtonPress_WithNoMoneyInserted_DisplaysProductPriceThenInsertCoins_DoesNotDispenseProduct()
            {
                var sut = new VendingMachine();
                sut.PushCandyButton();

                Assert.Equal(null, sut.ProductTray);
                Assert.Equal("PRICE: $0.65", sut.Display);
                Assert.Equal("INSERT COINS", sut.Display);
            }

            [Fact]
            public void ChipsButtonPress_WithNoMoneyInserted_DisplaysProductPriceThenInsertCoins_DoesNotDispenseProduct()
            {
                var sut = new VendingMachine();
                sut.PushChipsButton();

                Assert.Equal(null, sut.ProductTray);
                Assert.Equal("PRICE: $0.50", sut.Display);
                Assert.Equal("INSERT COINS", sut.Display);
            }
        }
    }
}