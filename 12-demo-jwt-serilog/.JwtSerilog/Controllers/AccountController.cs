using CodigoFacilito.JwtSerilog.Data;
using CodigoFacilito.JwtSerilog.Models;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodigoFacilito.JwtSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);

            if (user is not null)
            {
                // Crear el token

                var token = GenerateJwt(user);

                return Ok(token);
            }

            return NotFound("Usuario no encontrado");
        }

        private User Authenticate(LoginUser userLogin)
        {
            var currentUser = DBContext.Users
                .FirstOrDefault(user => user.Username.ToLower() == userLogin.UserName.ToLower()
                   && user.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        private string GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear los claims
            var claims = new[]
            {
             new Claim(JwtClaimTypes.Subject, user.Username),
             new Claim(JwtClaimTypes.Email, user.EmailAddress),
             new Claim(JwtClaimTypes.Name, user.FirstName),
             new Claim(JwtClaimTypes.FamilyName, user.LastName),
             new Claim(JwtClaimTypes.Role, user.Rol),
         };


            // Crear el token

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}
