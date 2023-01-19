using Microsoft.AspNetCore.Mvc;
using apiwhitef.Models;
using apiwhitef.Data;
using Microsoft.EntityFrameworkCore;

namespace apiwhitef.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase 
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            return await context.Products.Include(x => x.Category).ToListAsync();
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            return await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategoryId([FromServices] DataContext context, int id)
        {
            return await context.Products.
            Include(x => x.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context, 
            [FromBody] Product model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            context.Products.Add(model);
            await context.SaveChangesAsync();
            return model;
        }   
    }
}