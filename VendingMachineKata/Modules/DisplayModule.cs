using System;

namespace VendingMachineKata.Modules
{
    public class DisplayModule : IDisplayModule
    {
        private Boolean _resetToDefaultMessageAfterDisplay;
        private String _readOut;
        private Decimal _coinTotal;

        public String ReadOut {
            get
            {
                String message = _readOut;
                if (!_resetToDefaultMessageAfterDisplay)
                    return message;

                DefaultState();
                _resetToDefaultMessageAfterDisplay = false;
                return message;

            }
            private set { _readOut = value; } }
        public void DefaultState()
        {
            ReadOut = _coinTotal > 0 ? Messages.Total(_coinTotal) : Messages.InsertCoin;
        }

        public void UpdateInsertedCoinValue(Decimal coinTotal)
        {
            _coinTotal = coinTotal;
        }

        public void PurchaseMade()
        {
            ReadOut = Messages.ThankYou;
            _resetToDefaultMessageAfterDisplay = true;
        }

        public void InsufficientFundsForProduct(Decimal productPrice, Decimal valueForInsertedCoins)
        {
            ReadOut = Messages.ProductPrice(productPrice);
            _resetToDefaultMessageAfterDisplay = true;
        }

        public void ProductNotAvailable()
        {
            ReadOut = Messages.SoldOut;
            _resetToDefaultMessageAfterDisplay = true;
        }

        private static class Messages
        {
            public const String InsertCoin = "INSERT COINS";
            public const String ThankYou = "THANK YOU";
            public const String SoldOut = "SOLD OUT";

            public static String ProductPrice(Decimal price)
            {
                return $"PRICE: {price:C}";
            }

            public static String Total(Decimal totalValue)
            {
                return totalValue.ToString("C2");
            }
        }
    }
}