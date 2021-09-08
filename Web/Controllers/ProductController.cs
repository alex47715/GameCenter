using GameCenter.BLL.DTO;
using GameCenter.BLL.Services;
using GameCenter.DAL;
using GameCenter.DAL.Entities;
using GameCenter.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Web.Controllers
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
        [HttpGet("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetGames();

            if (products == null)
            {
                return NotFound("Products not found");
            }

            return Ok(products);
        }
        [HttpGet("products/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductDTO>> GetProduct([FromRoute] Guid id)
        {
            var product = await _productService.GetGameByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product with this id not found");
            }

            return Ok(product);
        }
        [HttpPost("products/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AddProduct([BindRequired, FromBody] ProductDTO product)
        {
            await _productService.CreateGameAsync(product);
            return Ok();
        }
        [HttpPut("products/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult UpdateProduct([BindRequired, FromBody] ProductDTO product)
        {
            _productService.UpdateGameAsync(product);
            return Ok();
        }
        [HttpDelete("products/{id}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
        {
            await _productService.DeleteGameAsync(id);
            return Ok();
        }
    }
}

