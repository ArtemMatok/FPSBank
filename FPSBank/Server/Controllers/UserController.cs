using FPSBank.Server.Authentication;
using FPSBank.Server.Repositories.Account;
using FPSBank.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPSBank.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserSession?>> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountRepository);
            var userSession = await  jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserName, loginRequest.Password);
            if (userSession is null)
                return Unauthorized();
            else
                return userSession;

        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserAccount>> Register(RegisterRequest model)
        {
            if (model is null) return BadRequest("model is null");
            var account = await _userAccountRepository.Register(model);
            return Ok(account);
        }
    }
}
