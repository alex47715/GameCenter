using GameCenter.BLL.DTO;
using GameCenter.BLL.Services;
using GameCenter.DAL.Entities;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<OrderDTO>>> GetAllOrders()
        {
            var products = await _orderService.GetOrders();

            if (products == null)
            {
                return NotFound("Products not found");
            }

            return Ok(products);
        }
        //[HttpPut("products/{id}/update")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public ActionResult UpdateGame([BindRequired, FromBody] ProductDTO product, [FromRoute] Guid id)
        //{
        //    _productService.UpdateGameAsync(product, id);
        //    return Ok();
        //}
        [HttpDelete("orders/{orderID}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder([FromRoute] Guid orderID)
        {
            await _orderService.DeleteOrder(orderID);
            return Ok();
        }
    }
}
