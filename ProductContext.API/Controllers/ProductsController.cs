using Microsoft.AspNetCore.Mvc;
using ProductContext.Application.DTOs;
using ProductContext.Application.UseCases.Product.Commands.interfaces;
using ProductContext.Application.UseCases.Product.Queries.interfaces;

namespace ProductContext.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Constructor

        private readonly IRequestProductByFilterUseCase _requestProductByFilterUseCase;
        private readonly IRequestProductByIdUseCase _requestProductByIdUseCase;
        private readonly IRegisterProductUseCase _registerProductUseCase;
        private readonly IUpdateProductUseCase _updateProductUseCase;
        private readonly IDisableProductUseCase _disableProductUseCase;
        public ProductsController(IRequestProductByFilterUseCase requestProductByFilterUseCase,
            IRequestProductByIdUseCase requestProductByIdUseCase,
            IRegisterProductUseCase registerProductUseCase,
            IUpdateProductUseCase updateProductUseCase,
            IDisableProductUseCase disableProductUseCase)
        {
            _requestProductByFilterUseCase = requestProductByFilterUseCase;
            _requestProductByIdUseCase = requestProductByIdUseCase;
            _registerProductUseCase = registerProductUseCase;
            _updateProductUseCase = updateProductUseCase;
            _disableProductUseCase = disableProductUseCase;
         
        }

        #endregion

        [HttpGet("search")]
        [ProducesResponseType(typeof(ResponseProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search([FromQuery] RequestProductDto request)
        {
            var products = await _requestProductByFilterUseCase.Handle(request);
            return Ok(products);
        }

       

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long id)
        {
            var product = await _requestProductByIdUseCase.Handle(id);
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] ProductDto productDto)
        {
            var product = await _registerProductUseCase.Handle(productDto);

            return CreatedAtAction(nameof(Register), new { id = product.Id }, productDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(long id, [FromBody] ProductDto productDto)
        {

            await _updateProductUseCase.Handle(id, productDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Disable(long id)
        {

            await _disableProductUseCase.Handle(id);

            return NoContent();
        }
    }
}
