namespace CashDustributor.Tests.Unit
{
    public class CashDistributorProccessorTests
    {
        private int _cashToAdd;

        public CashDistributorProccessorTests()
        {
            _cashToAdd = 1000;
        }

        [Fact]
        public void Should_CreateAnInstanceAndSetProperties_When_ParametersPassedToContructor()
        {
            // Arrange
            var cash = 10000;
            CashDistributorProccessor distributor;

            // Act
            distributor = new CashDistributorProccessor(cash);

            // Assert
            Assert.NotNull(distributor);
            Assert.Equal(cash, distributor.Cash);
        }

        [Fact]
        public void Should_IncreaseCash_When_AddCachMethodGetCalled()
        {
            // Arrange
            var existingCash = 10000;
            var expectedResult = 11000;
            var distributor = new CashDistributorProccessor(existingCash);

            // Act
            distributor.AddCash(_cashToAdd);

            // Assert
            Assert.Equal(expectedResult, distributor.Cash);
        }

        [Fact]
        public void Should_ThrowsException_When_CashToAddIsNegativeOrZero()
        {
            // Arrange
            var existingCash = 10000;
            _cashToAdd = -1;
            var distributor = new CashDistributorProccessor(existingCash);

            // Act
            Action act = () => distributor.AddCash(_cashToAdd);

            // Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("cashToAdd", ex.ParamName);
        }
    }
}