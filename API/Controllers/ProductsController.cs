using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    // First new "class" created in this lecture series, : derives from ControllerBase 

    // This is called an "attribute"
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // below are endpoints

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //return "this will be a list of products, plural";

            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        // specify id as route parameter to differentiate in httpget ""{id}""
        // "{id}" essentially if there's a number in the url its understood to get this method
        // rather than the one above

        // "dotnet watch run" autosaves and updates as you go, seems messy and risky
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
