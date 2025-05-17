using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using USERSERVICE.CoreLogic.DTO;
using USERSERVICE.CoreLogic.Entities;
using USERSERVICE.InfrastructureDB.Context;

namespace USERSERVICE.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserDbContext _db;
        private readonly IConfiguration _config;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UserDbContext db, IConfiguration config, ILogger<UsersController> logger)
        {
            _db = db;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            var user = _db.SELISE_USERS.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized();


            var token = GenerateJwtToken(user);
            _logger.LogInformation("token generated  at {Time}", DateTime.UtcNow);
            if (String.IsNullOrEmpty(token)) return BadRequest("Cannot Generate Token1!");
            return Ok(new LoginResponseDto
            {
                Token = token,
                Role = user.Role,
                Email = user.Email
            });
        }

        private string GenerateJwtToken(AppUser user)
        {
            try
            {
                var claims = new[]
                   {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Email),
        new Claim(ClaimTypes.Role, user.Role) // Critical
    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: "TeamService",
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds);


                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An unexpected error occurred.");
                return null;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll() => Ok(_db.SELISE_USERS.ToList());

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(AppUser user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _db.SELISE_USERS.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Guid id, AppUser updated)
        {
            var user = _db.SELISE_USERS.Find(id);
            if (user == null) return NotFound();
            user.FullName = updated.FullName;
            user.Role = updated.Role;
            _db.SaveChanges();
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            var user = _db.SELISE_USERS.Find(id);
            if (user == null) return NotFound();
            _db.SELISE_USERS.Remove(user);
            _db.SaveChanges();
            return NoContent();
        }


    }
}
