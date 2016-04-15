using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VendingMachineKata.Tests.Unit
{
    public partial class VendingMachineTests
    {
        public class AcceptCoinsTests
        {
            [Test]
            public void InitialState_HasZeroTotal_DisplaysInsertCoin()
            {
                var sut = GetDefaultInstance();
                Assert.AreEqual("INSERT COINS", sut.Display);
                Assert.AreEqual(0m, sut.Total);
            }

            [Test]
            [TestCaseSource(nameof(ValidCoinsWithValues))]
            public void InsertCoin_InsertValidCoin_SetsTotal_SetsDisplay(Coin validCoin, Decimal expectedTotal, String expectedDisplay)
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(validCoin);
                Assert.AreEqual(expectedDisplay, sut.Display);
                Assert.AreEqual(expectedTotal, sut.Total);
            }

            [Test]
            [TestCaseSource(nameof(InvalidCoins))]
            public void InsertCoin_InsertAnyNonValidCoin_DoesNotChangeTotal_SendsToCoinReturn(Coin invalidCoin)
            {
                var sut = GetDefaultInstance();
                Decimal previousTotal = sut.Total;
                String previousDisplay = sut.Display;

                sut.InsertCoin(invalidCoin);
                Assert.AreEqual(previousDisplay, sut.Display);
                Assert.AreEqual(previousTotal, sut.Total);
                Assert.That(sut.CoinReturnSlot, Has.Some.EqualTo(invalidCoin));
            }

            [Test]
            [TestCaseSource(nameof(InvalidCoins))]
            public void InsertCoin_InsertValidCoinsFollowedByInvalidCoin_DoesNotChangeTotal_SendsToCoinReturn(Coin invalidCoin)
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);

                Decimal validTotal = sut.Total;
                String validDisplay = sut.Display;

                sut.InsertCoin(invalidCoin);
                Assert.AreEqual(validDisplay, sut.Display);
                Assert.AreEqual(validTotal, sut.Total);
                Assert.That(sut.CoinReturnSlot, Has.Some.EqualTo(invalidCoin));
            }

            [Test]
            public void InsertCoin_InsertMultipleValidCoins_AddsToTotal_SetsDisplay()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Dime);
                Assert.AreEqual(0.15m, sut.Total);
                Assert.AreEqual("$0.15", sut.Display);
            }

            [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
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

            [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
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