using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Tests.Entities
{
    public class SuplierTest
    {
        [Fact]
        public void ShouldReturn_Success_When_PassValidArguments()
        {
            // Arrange
            string description = "Supplier Description";
            string cnpj = "12345678901234";

            // Act
            var supplier = new Supplier(description, cnpj);

            // Assert
            Assert.NotNull(supplier);
            Assert.Equal(description, supplier.Description);
            Assert.Equal(cnpj, supplier.CNPJ);
        }

    }
}