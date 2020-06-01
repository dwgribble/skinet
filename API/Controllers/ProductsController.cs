using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;

namespace API.Controllers
{
    // First new "class" created in this lecture series, : derives from ControllerBase 

    // This is called an "attribute"
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // below are endpoints

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //return "this will be a list of products, plural";

            //var products = await _context.Products.ToListAsync();

            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }

        // specify id as route parameter to differentiate in httpget ""{id}""
        // "{id}" essentially if there's a number in the url its understood to get this method
        // rather than the one above

        // "dotnet watch run" autosaves and updates as you go, seems messy and risky
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // this should return a single product? user selects a 
            // product from a list of products
            
            //return await _context.Products.FindAsync(id);

            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            // can't directly return an IReadOnlyList in asp.netcore
            // wrap in ok response
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            // can't directly return an IReadOnlyList in asp.netcore
            // wrap in ok response
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}
