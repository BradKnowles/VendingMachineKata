using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace VendingMachineKata
{
    public class VendingMachineTests
    {
        public class AcceptCoins
        {
            [Fact]
            public void InitialState_HasZeroTotal_DisplaysInsertCoin()
            {
                var sut = new VendingMachine();
                Assert.Equal("INSERT COIN", sut.Display);
                Assert.Equal(0m, sut.Total);
            }

            [Theory]
            [MemberData("ValidCoinsWithValues")]
            public void InsertCoin_InsertValidCoin_SetsTotal_SetsDisplay(Coin validCoin, Decimal expectedTotal, String expectedDisplay)
            {
                var sut = new VendingMachine();
                sut.InsertCoin(validCoin);
                Assert.Equal(expectedDisplay, sut.Display);
                Assert.Equal(expectedTotal, sut.Total);
            }

            [Theory]
            [MemberData("InvalidCoins")]
            public void InsertCoin_InsertAnyNonValidCoin_DoesNotChangeTotal_SendsToCoinReturn(Coin invalidCoin)
            {
                var sut = new VendingMachine();
                Decimal previousTotal = sut.Total;
                String previousDisplay = sut.Display;

                sut.InsertCoin(invalidCoin);
                Assert.Equal(previousDisplay, sut.Display);
                Assert.Equal(previousTotal, sut.Total);
                Assert.Equal(invalidCoin, sut.CoinReturn);
            }

            [Theory]
            [MemberData("InvalidCoins")]
            public void InsertCoin_InsertValidCoinsFollowedByInvalidCoin_DoesNotChangeTotal_SendsToCoinReturn(Coin invalidCoin)
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);

                Decimal validTotal = sut.Total;
                String validDisplay = sut.Display;

                sut.InsertCoin(invalidCoin);
                Assert.Equal(validDisplay, sut.Display);
                Assert.Equal(validTotal, sut.Total);
                Assert.Equal(invalidCoin, sut.CoinReturn);
            }

            [Fact]
            public void InsertCoin_InsertMultipleValidCoins_AddsToTotal_SetsDisplay()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Dime);
                Assert.Equal(0.15m, sut.Total);
                Assert.Equal("$0.15", sut.Display);
            }

            [SuppressMessage("ReSharper", "UnusedMember.Local")]
            private static IEnumerable<Object> ValidCoinsWithValues()
            {
                var coins = new Object[]
                {
                    new Object[] {Coins.Nickel, 0.05m, "$0.05"},
                    new Object[] {Coins.Dime, 0.10m, "$0.10"},
                    new Object[] {Coins.Quarter, 0.25m, "$0.25"},
                };
                return coins;
            }

            [SuppressMessage("ReSharper", "UnusedMember.Local")]
            private static IEnumerable<Object> InvalidCoins()
            {
                var coins = new Object[]
                {
                    new [] {Coins.Penny},
                    new [] {Coins.HalfDollar},
                    new [] {Coins.PresidentialDollar},
                    new [] {Coins.CanadianPenny},
                    new [] {Coins.CanadianNickel},
                    new [] {Coins.CanadianDime},
                    new [] {Coins.CanadianQuarter},
                    new [] {Coins.CanadianHalfDollar},
                    new [] {Coins.CanadianDollar},
                    new [] {Coins.CanadianTwoDollar}
                };
                return coins;
            }
        }

        public class SelectProduct
        {
            [Fact]
            public void ButtonPress_InsertCoinsForProduct_DispenseProduct_DisplaysThankYou()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();
                
                Assert.Equal(sut.Display, "THANK YOU");
                Assert.Equal(Products.Cola, sut.ProductTray);
            }
        }

        private static class Coins
        {
            // US Coin Information - https://www.usmint.gov/about_the_mint/?action=coin_specifications
            // Candian Coin Information - http://www.mint.ca/store/mint/about-the-mint/canadian-circulation-1100028
            public static Coin Penny => new Coin(2.5m, 19.05m);
            public static Coin Nickel => new Coin(5m, 21.21m);
            public static Coin Dime => new Coin(2.268m, 17.91m);
            public static Coin Quarter => new Coin(5.670m, 24.26m);
            public static Coin HalfDollar => new Coin(11.340m, 30.61m);
            public static Coin PresidentialDollar => new Coin(8.1m, 26.49m);
            public static Coin CanadianPenny => new Coin(2.35m, 19.05m);
            public static Coin CanadianNickel => new Coin(3.95m, 21.2m);
            public static Coin CanadianDime => new Coin(1.75m, 18.03m);
            public static Coin CanadianQuarter => new Coin(4.4m, 23.88m);
            public static Coin CanadianHalfDollar => new Coin(6.9m, 27.13m);
            public static Coin CanadianDollar => new Coin(6.27m, 26.5m);
            public static Coin CanadianTwoDollar => new Coin(6.92m, 28m);
        }

        private static class Products
        {
            public static Product Cola => new Product();
        }
    }

    public class Product
    {
    }
}