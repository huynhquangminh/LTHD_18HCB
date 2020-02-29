using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Service.Interface;
using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserService _userService;

        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetAllUsers")]
        public async Task<ActionResult<List<UserBO>>> GetAll()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [Route("Register")]
        public async Task<ActionResult<int>> Register(UserBO user)
        {
            return await _userService.AddUser(user);
        }

        /// <summary>
        /// Login account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [Route("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            UserBO login = new UserBO();
            login.UserName = username;
            login.Password = password;

            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var stringToken = GenerateJSONWebToken(user);
                response = Ok(new { token = stringToken });
            }

            return response;
        }

        /// <summary>
        /// Testing authorize
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetValue")]
        public ActionResult<IEnumerable<string>> TestAuthentication()
        {
            return new string[] { "Value1", "Value2", "Value3" };
        }

        private UserBO AuthenticateUser(UserBO login)
        {
            UserBO user = null;
            user = _userService.GetUserByUserNamePassword(login.UserName, login.Password).Result;

            return user;
        }

        private string GenerateJSONWebToken(UserBO userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
    }
}