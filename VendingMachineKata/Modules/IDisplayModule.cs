using System;

namespace VendingMachineKata.Modules
{
    public interface IDisplayModule
    {
        String ReadOut { get; }
        void DefaultState();
        void UpdateInsertedCoinValue(Decimal coinTotal);
        //void ShowValueInsertedCoins(Decimal value);
        void PurchaseMade();
        void InsufficientFundsForProduct(Decimal productPrice, Decimal valueInsertedCoins);
        void ProductNotAvailable();
    }
}