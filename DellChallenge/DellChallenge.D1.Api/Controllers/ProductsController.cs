using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using DellChallenge.D1.Api.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Get(string id)
        {
            var product = _productsService.GetAll().First(x => x.Id == id);
            if (product == null)
            {
                return NotFound($"Product with id {id} was not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public IActionResult Delete(string id)
        {
            try
            {
                _productsService.Delete(id);

                return NoContent();
            }
            catch (ProductException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected occurred. Please contact the system administration.");
            }
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public IActionResult Put(string id, [FromBody] UpdateProductDto product)
        {
            try
            {
                _productsService.Update(id, product);

                return NoContent();
            }
            catch (ProductException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected occurred. Please contact the system administration.");
            }
        }
    }
}
