using GeekShopping.Cart.API.Data.ValueObjects;
using GeekShopping.Cart.API.Messages;
using GeekShopping.Cart.API.RabbitMqSender;
using GeekShopping.Cart.API.Repository;
using GeekShopping.Cart.Data.ValueObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Cart.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartShoppingController : ControllerBase
    {
        private ICartShoppingRepository _cartRepository;
        private ICouponRepository _couponRepository;
        private IRabbitMqMessageSender _rabbitMQMessageSender;

        public CartShoppingController(ICartShoppingRepository cartRepository, ICouponRepository couponRepository, IRabbitMqMessageSender rabbitMQMessageSender)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
            _rabbitMQMessageSender = rabbitMQMessageSender ?? throw new ArgumentNullException(nameof(rabbitMQMessageSender));
        }

        [HttpGet("FindCart/{id}")]
        public async Task<ActionResult<CartShoppingVO>> FindById(string id)
        {
            var cart = await _cartRepository.FindCartByUserId(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("AddCart")]
        public async Task<ActionResult<CartShoppingVO>> AddCart(CartShoppingVO cartVo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(cartVo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("UpdateCart")]
        public async Task<ActionResult<CartShoppingVO>> UpdateCart(CartShoppingVO cartVo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(cartVo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("RemoveCart/{id}")]
        public async Task<ActionResult<CartShoppingVO>> RemoveCart(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("ApplyCoupon")]
        public async Task<ActionResult<CartHeaderVO>> ApplyCoupon(CartHeaderVO vo)
        {
            var status = await _cartRepository.ApplyCoupon(vo.UserId, vo.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpDelete("RemoveCoupon/{userId}")]
        public async Task<ActionResult<CartShoppingVO>> ApplyCoupon(string userId)
        {
            var status = await _cartRepository.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (vo?.UserId == null) return BadRequest();
            var cart = await _cartRepository.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();
            
            if (!string.IsNullOrEmpty(vo.CouponCode))
            {
                CouponVO coupon = await _couponRepository.GetCouponByCouponCode(vo.CouponCode, token);
                
                if (vo.DiscountAmount != coupon.DiscountAmount)               
                    return StatusCode(412);                
            }

            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            // RabbitMQ
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }
    }
}
