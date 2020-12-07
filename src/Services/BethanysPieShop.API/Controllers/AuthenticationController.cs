using System;
using BethanysPieShop.API.Models;
using BethanysPieShop.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BethanysPieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult TEST()
        {
            _logger.LogInformation($"TESTTTTTTTTT IS OOOOOOOOOOOOOOOOKKKKKKK");

            throw new Exception("asdddddddddddddddddd");

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Authenticate([FromBody]AuthenticationRequest request)
        {
            _logger.LogInformation($"AUTHENTICATION: {request.UserName}");

            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@something.com",
                    FirstName = "Gill",
                    LastName = "Cleeren",
                    UserName = request.UserName
                }
            });
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Register(string firstName, string lastName, string email, string userName, string password)
        {
            _logger.LogInformation($"REGISTRATION: {email}");

            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName
                }
            });
        }
    }
}
