using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private readonly IReadOnlyList<Coin> _validCoins;
        private readonly IReadOnlyDictionary<Coin, Decimal> _coinValueMapping;

        // US coin values obtained from https://www.usmint.gov/about_the_mint/?action=coin_specifications
        private static readonly Coin _nickel = new Coin(5m, 21.21m);
        private static readonly Coin _dime = new Coin(2.268m, 17.91m);
        private static readonly Coin _quarter = new Coin(5.670m, 24.26m);

        public VendingMachine()
        {
            _validCoins = SetupValidCoins();
            _coinValueMapping = MapCoinValues();
        }

        public void InsertCoin(Coin coin)
        {

            if (!_validCoins.Contains(coin))
            {
                CoinReturn = coin;
                return;
            }

            Total += _coinValueMapping[coin];
        }

        public String Display
        {
            get
            {
                if (Total == 0m)
                    return "INSERT COIN";

                return Total.ToString("C2");
            }
        }

        public Decimal Total { get; set; }

        public Coin CoinReturn { get; set; }

        private static IReadOnlyList<Coin> SetupValidCoins()
        {
            var validCoins = new List<Coin>
            {
                _nickel,
                _dime,
                _quarter
            };

            IReadOnlyList<Coin> readOnlyValidCoins = validCoins;
            return readOnlyValidCoins;
        }

        private static IReadOnlyDictionary<Coin, Decimal> MapCoinValues()
        {
            var values = new Dictionary<Coin, Decimal>
            {
                { _nickel, 0.05m},
                { _dime, 0.10m},
                { _quarter, 0.25m}
            };
            return new ReadOnlyDictionary<Coin, Decimal>(values);
        }
    }
}
