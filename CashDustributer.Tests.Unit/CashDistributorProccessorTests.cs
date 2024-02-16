namespace CashDustributor.Tests.Unit
{
    public class CashDistributorProccessorTests
    {
        private int _cashToAdd;
        private int _existingCash;
        private CashDistributorProccessor _distributor;

        public CashDistributorProccessorTests()
        {
            _cashToAdd = 1000;
            _existingCash = 10000;
            _distributor = new CashDistributorProccessor(_existingCash);
        }

        [Fact]
        public void Should_CreateAnInstanceAndSetProperties_When_ParametersPassedToContructor()
        {
            // Arrange
            var cash = 5000;
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
            var expectedResult = _existingCash + _cashToAdd;

            // Act
            _distributor.AddCash(_cashToAdd);

            // Assert
            Assert.Equal(expectedResult, _distributor.Cash);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_ThrowsException_When_CashToAddIsNegativeOrZero(int cashToAdd)
        {
            // Act
            Action act = () => _distributor.AddCash(cashToAdd);

            // Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("cashToAdd", ex.ParamName);
        }

        [Fact]
        public void Should_ThrowsException_When_CachValue_Not_Multiple_Of_Five()
        {

            // Act
            Action act = () => _distributor = new CashDistributorProccessor(1001);

            // Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("cash", ex.ParamName);
        }

        [Fact]
        public void Should_ThrowsException_When_AddCachValueIs_Not_Multiple_Of_Five()
        {
            // Arrange
            var cashToAdd = 7;

            // Act
            Action act = () => _distributor.AddCash(cashToAdd);

            // Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("cashToAdd", ex.ParamName);
        }
    }
}