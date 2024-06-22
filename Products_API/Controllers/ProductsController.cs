using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_API.Models;

namespace Products_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<product> products = new List<product>
        {
            new product{ Id=1, Name="BMW", Description="Black"},
            new product{ Id=2, Name="Marcedes", Description="Silver"},
            new product{ Id=3, Name="Mazda", Description="White"}
        };


        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult getProductById(int id)
        {
            var product = products.Find(product => product.Id == id);
            if(product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult addProduct(product request)
        {
            if(request is null)
            {
                return BadRequest();
            }

            product newProduct = new product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };

            products.Add(newProduct);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult updateProduct(int id, product request) {

            if (request is null)
            {
                return BadRequest();
            }
            
            var my_product = products.FirstOrDefault(product => product.Id == id);

            if(my_product is null)
            {
                return NotFound();
            }

            my_product.Name = request.Name;
            my_product.Description = request.Description;

            return Ok();
        }

        [HttpDelete]
        public IActionResult deleteProduct(int id)
        {
            var my_product = products.FirstOrDefault(product => product.Id == id);
            products.Remove(my_product);
            return Ok();
        }

    }
}
