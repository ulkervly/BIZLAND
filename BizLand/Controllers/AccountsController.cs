using BizLand.Business.DTOs.AccountDtos;
using BizLand.Business.DTOs.RegisterDtos;
using BizLand.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BizLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountsController(IMapper mapper,UserManager<AppUser> userManager,
                RoleManager<IdentityRole> roleManager,
                SignInManager<AppUser> signInManager,
                IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 400)]

        public async Task<IActionResult> Register(RegisterDto dto)
        {
            AppUser user = null;
            user = await _userManager.FindByNameAsync(dto.Username);

            if (user!= null)
            {
                return BadRequest("Bu adli istifadeci var ");
            }
            user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null)
            {
                return BadRequest("Bu emailli istifadeci var ");
            }

            user = _mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(user,dto.Password);

            var result2 = await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded) 
            {
                foreach (var item in result.Errors)
                {
                    return BadRequest(item.Description);
                }
            }

            return Ok(result2);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            AppUser user = null;
             user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);
            if (user == null) 
            {
                user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
                if (user == null) return BadRequest("Invalid username , email or password");
            }

            
            var result =  await _signInManager.PasswordSignInAsync(user,dto.Password,  false,false);
            if (!result.Succeeded) return BadRequest("Login oluna bilmedi");

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                
                new Claim(ClaimTypes.Name , user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["jwt:Key"]));

            var signinCreds = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(audience: _configuration["jwt:Audience"], 
                issuer: _configuration["jwt:Issuer"],
                claims: claims,
                notBefore : DateTime.UtcNow,
                expires:DateTime.UtcNow.AddHours(2),
                signingCredentials:signinCreds);

            var token =new  JwtSecurityTokenHandler().WriteToken(jwt);  

            return Ok(token);
            
        }


    }
}
