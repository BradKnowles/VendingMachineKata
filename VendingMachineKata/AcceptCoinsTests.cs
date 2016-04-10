using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace VendingMachineKata
{
    public partial class VendingMachineTests
    {
        public class AcceptCoinsTests
        {
            [Fact]
            public void InitialState_HasZeroTotal_DisplaysInsertCoin()
            {
                var sut = new VendingMachine();
                Assert.Equal("INSERT COINS", sut.Display);
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
                Assert.Contains(invalidCoin, sut.CoinReturnSlot);
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
                Assert.Contains(invalidCoin, sut.CoinReturnSlot);
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
    }
}