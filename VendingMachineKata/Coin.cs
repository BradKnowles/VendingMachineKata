using System;

namespace VendingMachineKata
{
    public class Coin
    {
        public Decimal WeightInGrams { get; set; }
        public Decimal DiameterinMillimeters { get; set; }

        public Coin(Decimal weightInGrams, Decimal diameterinMillimeters)
        {
            WeightInGrams = weightInGrams;
            DiameterinMillimeters = diameterinMillimeters;
        }
    }
}