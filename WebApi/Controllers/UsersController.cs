using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager; 
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaUsuario")]
        public async Task<IActionResult> AdicionaUsuario([FromBody] CreateUserInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) || 
                string.IsNullOrWhiteSpace(input.Password) ||
                string.IsNullOrWhiteSpace(input.Cpf))
            {
                return Ok("Falta alguns dados");
            }

            var user = new ApplicationUser
            {
                Email = input.Email,
                UserName = input.Email,
                CPF = input.Cpf,
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Errors.Any())
                return Ok(result.Errors);

            // Geração Confirmação Email

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // Retorno do Email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var response_Retorno = await _userManager.ConfirmEmailAsync(user, code);

            if (response_Retorno.Succeeded)
            {
                return Ok("Usuário Adicionado");
            }
            return Ok("Erro ao confirmar cadastro do usuário");
        }
    }
}
