using GameCenter.BLL.DTO;
using GameCenter.BLL.Services;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        public UserController(IUserService userService,IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }
        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            var products = await _userService.GetAllUsers();

            if (products == null)
            {
                return NotFound("Users not found");
            }

            return Ok(products);
        }
        [HttpGet("users/{userID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductDTO>> GetUserById([FromRoute] Guid userID)
        {
            var product = await _userService.GetUserById(userID);

            if (product == null)
            {
                return NotFound("User with this id not found");
            }

            return Ok(product);
        }
        [HttpPost("users/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AddUser([FromBody] UserDTO user)
        {
            await _userService.Create(user);
            return Ok();
        }
        [HttpPost("users/{userID}/orders/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AddUserOrder([FromRoute] Guid userID, [FromBody] int count, Guid productID)
        {
            await _userService.AddOrder(userID,productID,count);
            return Ok();
        }
        [HttpGet("users/{userID}/orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<OrderDTO>>> GetUserOrder([FromRoute] Guid userID)
        {
            var result = await _orderService.GetUserOrders(userID);
            return Ok(result);
        }
        [HttpPut("users/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult UpdateUser([FromBody] UserDTO user)
        {
            _userService.Update(user);
            return Ok();
        }
        [HttpDelete("users/{userID}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid userID)
        {
            await _userService.Delete(userID);
            return Ok();
        }
    }
}
