using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sahm.Server.Extention;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;
using System.IdentityModel.Tokens.Jwt;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IClaimsService _claimsService;
        private readonly IJwtTokenService _jwtTokenService;
        public UserController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IClaimsService claimsService,
            IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _claimsService = claimsService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            IdentityResult result;

            AppUser newUser = new()
            {
                Name = userRegisterDTO.Name,
                JobTitle_Id = userRegisterDTO.JobTitle,
                Email = userRegisterDTO.Email,
                UserName = userRegisterDTO.Email,
                Mobile = userRegisterDTO.Mobile,
                PicURL = userRegisterDTO.PicURL,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            result = await _userManager.CreateAsync(newUser, userRegisterDTO.Password);

            if (!result.Succeeded)
                return Conflict(new UserRegisterResultDTO
                {
                    Succeeded = result.Succeeded,
                    Errors = result.Errors.Select(e => e.Description)
                });

            await SeedRoles();
            result = await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return CreatedAtAction(nameof(Register), new UserRegisterResultDTO { Succeeded = true });
        }

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                await _roleManager.CreateAsync(new AppRole(UserRoles.SuperAdmin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.MaintenanceAdmin))
                await _roleManager.CreateAsync(new AppRole(UserRoles.MaintenanceAdmin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.QulityAdmin))
                await _roleManager.CreateAsync(new AppRole(UserRoles.QulityAdmin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.BuyAdmin))
                await _roleManager.CreateAsync(new AppRole(UserRoles.BuyAdmin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.SuperVisor))
                await _roleManager.CreateAsync(new AppRole(UserRoles.SuperVisor));

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new AppRole(UserRoles.User));
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                var userClaims = await _claimsService.GetUserClaimsAsync(user);

                var token = _jwtTokenService.GetJwtToken(userClaims);

                return Ok(new UserLoginResultDTO
                {
                    Succeeded = true,
                    Token = new TokenDTO
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    }
                });
            }

            return Unauthorized(new UserLoginResultDTO
            {
                Succeeded = false,
                Message = "The email and password combination was invalid."
            });
        }

        [HttpPost]
        [Route("ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(changePasswordDTO.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, changePasswordDTO.CurrentPassword))
            {
                await _userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);
                return Ok();
            }
            else
            {
                return BadRequest("current password not match with current user");
            }
        }
    }
}
