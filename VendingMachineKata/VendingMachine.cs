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
        private readonly IReadOnlyList<Product> _products;
        private String _display;

        // US coin values obtained from https://www.usmint.gov/about_the_mint/?action=coin_specifications
        // ReSharper disable InconsistentNaming
        private static readonly Coin _nickel = new Coin(5m, 21.21m);
        private static readonly Coin _dime = new Coin(2.268m, 17.91m);
        private static readonly Coin _quarter = new Coin(5.670m, 24.26m);
        private Boolean _resetDisplayOnNextGet;
        // ReSharper restore InconsistentNaming

        public VendingMachine()
        {
            _validCoins = SetupValidCoins();
            _coinValueMapping = MapCoinValues();
            _products = InitializeProducts();
            Display = DisplayMessages.InsertCoin;
        }

        public void InsertCoin(Coin coin)
        {

            if (!_validCoins.Contains(coin))
            {
                CoinReturn = coin;
                return;
            }

            Total += _coinValueMapping[coin];
            Display = Total.ToString("C2");
        }

        public String Display
        {
            get
            {
                if (!_resetDisplayOnNextGet)
                    return _display;

                String currentDisplay = _display;
                _display = DisplayMessages.InsertCoin;
                return currentDisplay;
            }
            set
            {
                _display = value;
            }
        }

        public Decimal Total { get; set; }

        public Coin CoinReturn { get; set; }

        public Product ProductTray { get; set; }

        public void PushColaButton()
        {
            var cola = _products.First(x => x.Name == "Cola");
            if (Total == cola.Price)
            {
                ProductTray = cola;
                Display = DisplayMessages.ThankYou;
                _resetDisplayOnNextGet = true;
            }
        }

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

        private static IReadOnlyList<Product> InitializeProducts()
        {
            var values = new List<Product>
            {
                {new Product("Cola", 1m)},
                {new Product("Chips", 0.50m)},
                {new Product("Candy", 0.65m)}
            };

            IReadOnlyList<Product> products = values;
            return products;
        }

        private static class DisplayMessages
        {
            public const String InsertCoin = "INSERT COIN";
            public const String ThankYou = "THANK YOU";
        }
    }
}
