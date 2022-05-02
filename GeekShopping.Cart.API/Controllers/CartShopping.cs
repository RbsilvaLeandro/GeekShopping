using GeekShopping.Cart.API.Data.ValueObjects;
using GeekShopping.Cart.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Cart.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartShoppingController : ControllerBase
    {
        private ICartShoppingRepository _repository;

        public CartShoppingController(ICartShoppingRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("FindCart/{id}")]
        public async Task<ActionResult<CartShoppingVO>> FindById(string Id)
        {
            var cart = await _repository.FindCartByUserId(Id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("AddCart")]
        public async Task<ActionResult<CartShoppingVO>> AddCart(CartShoppingVO cartVo)
        {
            var cart = await _repository.SaveOrUpdateCart(cartVo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("UpdateCart")]
        public async Task<ActionResult<CartShoppingVO>> UpdateCart(CartShoppingVO cartVo)
        {
            var cart = await _repository.SaveOrUpdateCart(cartVo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("RemoveCart/{id}")]
        public async Task<ActionResult<CartShoppingVO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("ApplyCoupon")]
        public async Task<ActionResult<CartHeaderVO>> ApplyCoupon(CartHeaderVO vo)
        {
            var status = await _repository.ApplyCoupon(vo.UserId, vo.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpDelete("RemoveCoupon/{userId}")]
        public async Task<ActionResult<CartShoppingVO>> ApplyCoupon(string userId)
        {
            var status = await _repository.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }
    }
}
