using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{

    [Route("api/v1/[controller]")]
    public class CatalogController : Controller
    {
        private ILogger<CatalogController> _logger { get; set; }
        private IProductRepository _productRepository { set; get; }
        public CatalogController(ILogger<CatalogController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)StatusCodes.Status200OK)]
        // in asp.net core mvc we can return ActionResult as the class is inheriting from Controller class unlike asp.net web api where it inherits from 
        // controllerbase.
        public ActionResult<IEnumerable<Product>> GetProducts()

        {

            return Ok(_productRepository.GetProducts());
        }

        // Id here is bson represenstation for mongodb
        [HttpGet("{Id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Product), (int)StatusCodes.Status200OK)]
        public ActionResult<Product> GetProductById(string Id)
        {
            var product = _productRepository.GetProductById(Id);
            if (product == null)
            {
                _logger.LogError($"Product with id: {Id} is not found in mongo collection");
                return NotFound();

            }
            return Ok(product);
        }

        [Route("[action]/{catergory}", Name = "GetProductByCategory")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Product), (int)StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<Product> GetProductByCategory(string category)
        {
            var product = _productRepository.GetProductByCategory(category);
            if (product == null)
            {
                _logger.LogError($"Product with catergory: {category} is not found in mongo collection");
                return NotFound();

            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)StatusCodes.Status200OK)]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
             _productRepository.CreateProduct(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id },product);
            
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)StatusCodes.Status200OK)]
        public ActionResult<Product> UpdateProduct([FromBody] Product product)
        {
            var result =  _productRepository.UpdateProduct(product);
            if(result)
            {
                return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
            }

            return product;

        }

        
        [ProducesResponseType(typeof(Product), (int)StatusCodes.Status200OK)]
        [HttpDelete("{Id:length(24)}", Name = "DeleteProduct")]
        public IActionResult DeleteProduct(string id)
        {
            return Ok(_productRepository.DeleteProduct(id));
            

        }
    }
}
