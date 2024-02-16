namespace CashDustributor.Tests.Unit
{
    public class CashDistributorProccessorTests
    {
        private readonly CashDistributorProccessor _distributor;

        public CashDistributorProccessorTests()
        {
            _distributor = new CashDistributorProccessor();
        }

        [Fact]
        public void Should_IncreaseBanknotesStockForEachType_When_AddBanknotesGetCalled()
        {
            // Arrange
            var five = new FiveDinnars();
            var ten = new TenDinnars();

            // Act
            _distributor.AddBanknotes(five, 10);
            _distributor.AddBanknotes(ten, 5);

            Assert.NotNull(five);
            Assert.NotNull(ten);
            Assert.True(five.Value == 5);
            Assert.True(ten.Value == 10);
            Assert.True(_distributor.BankNotes.Count == 15);
            Assert.True(_distributor.BankNotes.Count(x => x is FiveDinnars) == 10);
            Assert.True(_distributor.BankNotes.Count(x => x is TenDinnars) == 5);

        }

        [Fact]
        public void Should_DecreaseBanknotesStockForEachType_When_RemoveBanknotesGetCalled()
        {
            // Arrange
            var bankNotesToRemove = new List<BaseBankNote> { new FiveDinnars(), new TenDinnars() };
            var five = new FiveDinnars();
            var ten = new TenDinnars();
            _distributor.AddBanknotes(five, 10);
            _distributor.AddBanknotes(ten, 5);

            // Act
            _distributor.RemoveBanknotes(bankNotesToRemove);

            Assert.True(_distributor.BankNotes.Count == 13);
            Assert.True(_distributor.BankNotes.Count(x => x is FiveDinnars) == 9);
            Assert.True(_distributor.BankNotes.Count(x => x is TenDinnars) == 4);
        }

        [Fact]
        public void Should_HaveCorrect_CashAmount_When_BankNotesAdded()
        {
            // Arrange
            var five = new FiveDinnars();
            var ten = new TenDinnars();

            // Act
            _distributor.AddBanknotes(five, 1);
            _distributor.AddBanknotes(ten, 2);

            // Assert
            Assert.Equal(25, _distributor.CashAmount);
        }
    }
}