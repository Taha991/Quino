using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;

        public ProductController(AppDbContext context , IProductRepository productRepository )
        {
            _context = context;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>>  GetProducts()
        {

            var products =  await _productRepository.GetAllProductsAsync();

            return Ok(products);

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id) {

            var products =await  _productRepository.GetProductByIdAsync(id);

            return Ok(products);

        }

    }
}
