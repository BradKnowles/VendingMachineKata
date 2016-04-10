using Xunit;

namespace VendingMachineKata
{
    public partial class VendingMachineTests
    {
        public class SoldOutTests
        {
            [Fact]
            public void ColaButtonPress_NoCoinsInserted_WithColaSoldOut_DisplaySoldOutThenInsertCoins()
            {
                var sut = new VendingMachine();
                sut.UpdateProductStatus("Cola", "SOLD OUT");

                sut.PushColaButton();

                Assert.Equal("SOLD OUT", sut.Display);
                Assert.Equal("INSERT COINS", sut.Display);
            }
        }
    }
}