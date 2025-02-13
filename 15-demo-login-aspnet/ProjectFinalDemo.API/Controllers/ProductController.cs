using Microsoft.AspNetCore.Mvc;
using ProjectFinalDemo.Application.Models.Products;
using ProjectFinalDemo.Application.Services.Interfaces;

namespace ProjectFinalDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductRequestModel product)
        {
            await _productService.Add(product);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductRequestModel product, int id)
        {
            await _productService.Update(product, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
