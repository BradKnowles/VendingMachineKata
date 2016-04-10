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

        private readonly List<Coin> _insertedCoins; 
        private readonly List<Coin> _coinReturn; 

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
            _insertedCoins = new List<Coin>();
            _coinReturn = new List<Coin>();
        }

        public void InsertCoin(Coin coin)
        {

            if (!_validCoins.Contains(coin))
            {
                _coinReturn.Add(coin);
                return;
            }

            _insertedCoins.Add(coin);
            Total += _coinValueMapping[coin];
            Display = TotalFormatted;
        }

        public String Display
        {
            get
            {
                if (_resetDisplayOnNextGet)
                {
                    String currentDisplay = _display;
                    _display = Total > 0 ? TotalFormatted : DisplayMessages.InsertCoin;
                    return currentDisplay;
                }
                return _display;
            }
            set
            {
                _display = value;
            }
        }

        public Decimal Total { get; set; }
        public String TotalFormatted => Total.ToString("C2");

        public IEnumerable<Coin> CoinReturnSlot => _coinReturn.ToArray();

        public Product ProductTray { get; set; }

        public void PushColaButton()
        {
            var cola = _products.First(x => x.Name == "Cola");
            DispenseProduct(cola);
        }

        public void PushCandyButton()
        {
            var candy = _products.First(x => x.Name == "Candy");
            DispenseProduct(candy);
        }

        public void PushChipsButton()
        {
            var chips = _products.First(x => x.Name == "Chips");
            DispenseProduct(chips);
        }

        private void DispenseProduct(Product product)
        {
            if (Total < product.Price)
            {
                Display = DisplayMessages.Price(product.Price);
                _resetDisplayOnNextGet = true;
                return;
            }

            ProductTray = product;
            Display = DisplayMessages.ThankYou;
            //CoinReturnTotal = Total - product.Price;
            Total = 0m;
            _resetDisplayOnNextGet = true;
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
            public const String InsertCoin = "INSERT COINS";
            public const String ThankYou = "THANK YOU";

            public static String Price(Decimal price)
            {
                return $"PRICE: {price:C}";
            }
        }

        public void ReturnCoins()
        {
            _coinReturn.AddRange(_insertedCoins);
            _insertedCoins.Clear();
            Total = 0m;
            Display = DisplayMessages.InsertCoin;
        }
    }
}
