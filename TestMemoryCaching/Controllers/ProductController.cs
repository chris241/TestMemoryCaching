using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMemoryCaching.Services;

namespace TestMemoryCaching.Controllers
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
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _productService.GetAll(cancellationToken);
            return Ok(response);
        }
    }
}
