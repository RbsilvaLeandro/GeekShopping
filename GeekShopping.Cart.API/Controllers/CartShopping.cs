using GeekShopping.Cart.API.Data.ValueObjects;
using GeekShopping.Cart.API.Messages;
using GeekShopping.Cart.API.RabbitMqSender;
using GeekShopping.Cart.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Cart.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartShoppingController : ControllerBase
    {
        private ICartShoppingRepository _repository;
        private IRabbitMqMessageSender _rabbitMQMessageSender;

        public CartShoppingController(ICartShoppingRepository repository, IRabbitMqMessageSender rabbitMQMessageSender)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));

            _rabbitMQMessageSender = rabbitMQMessageSender
                           ?? throw new ArgumentNullException(nameof(rabbitMQMessageSender));
        }

        [HttpGet("FindCart/{id}")]
        public async Task<ActionResult<CartShoppingVO>> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);
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

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            if (vo?.UserId == null) return BadRequest();
            var cart = await _repository.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();
            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            //RabbitMQ logic comes here!!!
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }
    }
}
