using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VendingMachineKata.Modules;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private readonly IReadOnlyList<Coin> _validCoins;
        private readonly IReadOnlyDictionary<Coin, Decimal> _coinValueMapping;
        private readonly IReadOnlyList<Product> _products;
        private Dictionary<Product, String> _productStatus;
        private readonly IDisplayModule _displayModule;

        private readonly List<Coin> _insertedCoins;
        private readonly List<Coin> _coinReturn;

        // US coin values obtained from https://www.usmint.gov/about_the_mint/?action=coin_specifications
        // ReSharper disable InconsistentNaming
        private static readonly Coin _nickel = new Coin(5m, 21.21m);
        private static readonly Coin _dime = new Coin(2.268m, 17.91m);
        private static readonly Coin _quarter = new Coin(5.670m, 24.26m);
        // ReSharper restore InconsistentNaming
        private Decimal _total;

        public VendingMachine(IDisplayModule displayModule)
        {
            _displayModule = displayModule;

            _validCoins = SetupValidCoins();
            _coinValueMapping = MapCoinValues();
            _products = InitializeProducts();
            InitializeProductStatuses();

            _displayModule.DefaultState();
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
            _displayModule.DefaultState();
        }

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
            if (!ProductIsAvailable(product))
            {
                _displayModule.ProductNotAvailable();
                return;
            }

            if (Total < product.Price)
            {
                _displayModule.InsufficientFundsForProduct(product.Price, Total);
                return;
            }

            ProductTray = product;
            ProcessRefund(Total - product.Price);
            _displayModule.PurchaseMade();
            Total = 0m;
        }

        public String Display => _displayModule.ReadOut;

        public Decimal Total
        {
            get { return _total; }
            set
            {
                _displayModule.UpdateInsertedCoinValue(value);
                _total = value;
            }
        }

        public String TotalFormatted => Total.ToString("C2");

        public IEnumerable<Coin> CoinReturnSlot => _coinReturn.ToArray();
        public Decimal CoinReturnTotal
        {
            get
            {
                Decimal value = _coinReturn.Select(x => _coinValueMapping[x]).Sum();
                return value;
            }
        }

        public Product ProductTray { get; set; }

        private Boolean ProductIsAvailable(Product product)
        {
            return _productStatus[product] != "SOLD OUT";
        }

        private void ProcessRefund(Decimal amountToRefund)
        {
            var refundRemaining = amountToRefund;
            while (refundRemaining > 0)
            {
                var numberOfQuarters = refundRemaining / _coinValueMapping[_quarter];
                do
                {
                    if (numberOfQuarters >= 1)
                    {
                        _coinReturn.Add(_quarter);
                        refundRemaining -= _coinValueMapping[_quarter];
                    }
                    numberOfQuarters = refundRemaining / _coinValueMapping[_quarter];
                } while (numberOfQuarters >= 1);

                var numberOfDimes = refundRemaining / _coinValueMapping[_dime];
                do
                {
                    if (numberOfDimes >= 1)
                    {
                        _coinReturn.Add(_dime);
                        refundRemaining -= _coinValueMapping[_dime];
                    }
                    numberOfDimes = refundRemaining / _coinValueMapping[_dime];
                } while (numberOfDimes >= 1);

                var numberOfNickels = refundRemaining / _coinValueMapping[_nickel];
                do
                {
                    if (numberOfNickels >= 1)
                    {
                        _coinReturn.Add(_nickel);
                        refundRemaining -= _coinValueMapping[_nickel];
                    }
                    numberOfNickels = refundRemaining / _coinValueMapping[_nickel];
                } while (numberOfNickels >= 1);
            }
        }

        public void ReturnCoins()
        {
            _coinReturn.AddRange(_insertedCoins);
            _insertedCoins.Clear();
            Total = 0m;
            _displayModule.DefaultState();
        }

        public void UpdateProductStatus(String productName, String status)
        {
            var product = _products.FirstOrDefault(x => x.Name == productName);
            if (product != null)
                _productStatus[product] = status;
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

        private void InitializeProductStatuses()
        {
            _productStatus = new Dictionary<Product, String>();
            foreach (var product in _products)
            {
                _productStatus.Add(product, "AVAILABLE");
            }
        }
    }
}
