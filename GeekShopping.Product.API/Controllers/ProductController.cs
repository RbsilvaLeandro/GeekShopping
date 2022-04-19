using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(Repository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Findall()
        {
            var product = await _productRepository.FindAll();
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();
            var createProduct = await _productRepository.Create(product);
            
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();
            var createProduct = await _productRepository.Update(product);

            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        
    }
}
