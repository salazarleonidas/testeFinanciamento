using CreditoApplication.Services.Interfaces;
using CreditoApplication.Shared.Users.Repository;
using CreditoApplication.Shared.Users.ViewModels;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TesteCredito.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] UserViewModel model)
        {
            // Recupera o usu�rio
            var user = _userService.Get(model.Username, model.Password);

            // Verifica se o usu�rio existe
            if (user == null)
                return NotFound(new { message = "Usu�rio ou senha inv�lidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(model.Username);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Authorize]
        public string Authenticated() => string.Format("Autenticado - {0}", User?.Identity?.Name);

    }
}