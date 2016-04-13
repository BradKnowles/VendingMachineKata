using System;

namespace VendingMachineKata.Modules
{
    public interface IDisplayModule
    {
        String ReadOut { get; }
        void DefaultState();
        void UpdateInsertedCoinValue(Decimal coinTotal);
        void PurchaseMade();
        void InsufficientFundsForProduct(Decimal productPrice);
        void ProductNotAvailable();
    }
}