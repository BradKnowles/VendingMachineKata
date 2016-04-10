using System;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        public void InsertCoin(Coin coin)
        {
            if (coin.WeightInGrams == 2.5m && coin.DiameterinMillimeters == 19.05m)
            {
                Display = "$0.00";
                CoinReturn = coin;
                Total = 0m;
            }
            else
            {
                Display = "$0.05";
                Total = .05m;
            }
        }

        public String Display { get; set; }
        public Decimal Total { get; set; }
        public Coin CoinReturn { get; set; }
    }
}