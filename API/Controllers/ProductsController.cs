using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.Data;

namespace API.Controllers
{
    
    public class ProductsController(StoreContext context) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()//this runs (by default) when we hit the endpoint http://localhost:5263/api/products
        {
          
           
            return await context.Products.ToListAsync();//see the products seeded by DbInitializer.cs
        }
        [HttpGet("{id}")]//api/products/3
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }
    }
}