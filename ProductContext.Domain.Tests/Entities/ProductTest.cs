using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Tests.Entities
{
    public class ProductTest
    {
        [Fact]
        public void ShouldReturn_Exception_When_ExpirationDateEqualsManufactureDate()
        {
            //arrange

            Action action = () => new Product("notebook", DateTime.Now, DateTime.Now, 1);

            var exception = Assert.Throws<InvalidProductException>(action);

            Assert.Contains("Produto Invalido", exception.Message);
        }

        [Fact]
        public void ShouldReturn_Active_When_RegisterProduct()
        {
            //arrange
            var product = new Product("notebook", DateTime.Now, DateTime.Now.AddMonths(1), 1);
            //assert
            Assert.True(product.IsActive);
        }

        [Fact]
        public void ShouldReturn_InactiveProduct_When_DisableProduct()
        {
            //arrange
            var product = new Product("notebook", DateTime.Now, DateTime.Now.AddMonths(1), 1, true);
            // act
            product.Disable();
            //assert
            Assert.False(product.IsActive);
        }
    }
}