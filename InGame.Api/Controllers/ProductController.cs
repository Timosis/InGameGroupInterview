using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InGame.Api.DataService;
using InGame.Api.Models;
using InGame.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public IProductDataService _productDataService;

        public ProductController(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct([FromBody]Product productToCreate)
        {
            if (productToCreate == null)
                return BadRequest(ModelState);

            var product = _productDataService.GetProducts()
                            .Where(c => c.Name.Trim().ToUpper() == productToCreate.Name.Trim().ToUpper())
                            .FirstOrDefault();

            if (product != null)
            {
                ModelState.AddModelError("", $"Product {productToCreate.Name} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_productDataService.CreateProduct(productToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving {productToCreate.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetProduct", new { productId = productToCreate.Id }, productToCreate);
        }
        
        [Route("GetProduct")]
        public IActionResult GetProduct(int productId)
        {
            if (!_productDataService.ProductExists(productId))
                return NotFound();


            var product = _productDataService.GetProduct(productId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productDto = new ProductDto
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description,
            };

            return Ok(productDto);
        }

        [Route("GetProduct")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            if (!(categoryId > 0))
                return NotFound();

            var products = _productDataService.GetProductsByCategory(categoryId);

            if (!(products.Count > 0))
                return NotFound("There is no product in this category");

            return Ok(products);
        }

        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody]Product updatedProduct, int productId)
        {

            if (updatedProduct == null)
                return BadRequest(ModelState);

            if (productId != updatedProduct.Id)
                return BadRequest(ModelState);

            if (!_productDataService.ProductExists(productId))
                return NotFound();

            if (_productDataService.IsDuplicateProductName(productId, updatedProduct.Name))
            {
                ModelState.AddModelError("", $"Country {updatedProduct.Name} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_productDataService.UpdateProduct(updatedProduct))
            {
                ModelState.AddModelError("", $"Something went wrong updating {updatedProduct.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct([FromBody]int productId)
        {
            if (!_productDataService.ProductExists(productId))
                return NotFound();

            var product = _productDataService.GetProduct(productId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_productDataService.DeleteProduct(product))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting {product.Name}");
                return StatusCode(500, ModelState);
            }

            ModelState.AddModelError("", $"{product.Name} is deleted");

            return StatusCode(500,ModelState);
        }

        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _productDataService.GetProducts();
            if (!(products.Count > 0))
                return NotFound("There is no products");

            return Ok(products);

        }
    }
}