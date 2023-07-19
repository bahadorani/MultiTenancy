using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Services;

namespace Sample.Api.Controllers
{
    
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UserService _userService;
        private ProductService _productService;

        public ValuesController(UserService userService, ProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }

        [HttpGet]
        [Route("api/[controller]/getusers")]
        public IActionResult GetUser()
        {
            var result = _userService.GetUsers();
            return Ok(result);
        }
        [HttpGet]
        [Route("api/[controller]/getproduct")]
        public IActionResult GetProduct()
        {
            var result = _productService.GetProduct();
            return Ok(result);
        }
    }
}
