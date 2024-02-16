namespace CashDustributor.Tests.Unit
{
    public class CashDistributorProccessorTests
    {
        private int _cashToAdd;
        private int _existingCash;
        private readonly CashDistributorProccessor _distributor;

        public CashDistributorProccessorTests()
        {
            _cashToAdd = 1000;
            _existingCash = 10000;
            _distributor = new CashDistributorProccessor();
        }

        [Fact]
        public void Should_IncreaseBanknotesStockForEachType_When_AddBanknotesGetCalled()
        {
            // Arrange
            var fives = new FiveDinnars();
            var tens = new TenDinnars();

            // Act
            _distributor.AddBanknotes(fives, 10);
            _distributor.AddBanknotes(tens, 5);

            Assert.NotNull(fives);
            Assert.NotNull(tens);
            Assert.True(fives.Value == 5);
            Assert.True(tens.Value == 10);
            Assert.True(_distributor.BankNotes.Count == 15);
            Assert.True(_distributor.BankNotes.Count(x => x is FiveDinnars) == 10);
            Assert.True(_distributor.BankNotes.Count(x => x is TenDinnars) == 5);

        }

        [Fact]
        public void Should_DecreaseBanknotesStockForEachType_When_RemoveBanknotesGetCalled()
        {
            // Arrange
            var bankNotesToRemove = new List<BaseBankNote> { new FiveDinnars(), new TenDinnars() };
            var fives = new FiveDinnars();
            var tens = new TenDinnars();
            _distributor.AddBanknotes(fives, 10);
            _distributor.AddBanknotes(tens, 5);

            // Act
            _distributor.RemoveBanknotes(bankNotesToRemove);

            Assert.True(_distributor.BankNotes.Count == 13);
            Assert.True(_distributor.BankNotes.Count(x => x is FiveDinnars) == 9);
            Assert.True(_distributor.BankNotes.Count(x => x is TenDinnars) == 4);
        }
    }
}