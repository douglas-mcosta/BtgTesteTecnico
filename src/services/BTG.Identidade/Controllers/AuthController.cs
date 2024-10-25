using BTG.Core.Messages.Integration;
using BTG.Identidade.API.Extensions;
using BTG.Identidade.API.Models;
using BTG.Identidade.API.Services.NSE.Identidade.API.Services;
using BTG.MessageBus;
using BTG.WebAPI.Core.Controllers;
using BTG.WebAPI.Core.Identidate;
using BTG.WebAPI.Core.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BTG.Identidade.API.Controllers
{
    [Route("auth")]
    public class AuthController : MainController
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenSettings _appSettings;
        private readonly AuthenticationService _authenticationService;
        private readonly IMessageBus _bus;
        private readonly IAspNetUser _aspNetUser;
        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<TokenSettings> appSettings,
                              IMessageBus bus,
                              IAspNetUser aspNetUser,
                              AuthenticationService authenticationService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _bus = bus;
            _aspNetUser = aspNetUser;
            _authenticationService = authenticationService;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Register(RegistroUsuarioViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                var clienteResult = await RegistrarCliente(model);

                if (!clienteResult.ValidationResult.IsValid)
                {
                    await _authenticationService.UserManager.DeleteAsync(user);
                    return CustomResponse(clienteResult.ValidationResult);
                }

                return CustomResponse(await _authenticationService.GerarJwt(model.Email));
            }

            foreach (var erro in result.Errors)
                AdicionarErroProcessamento(erro.Description);

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _authenticationService.SignInManager.PasswordSignInAsync(model.Email, model.Senha, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await _authenticationService.GerarJwt(model.Email));
            }

            if (result.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas invalidas.");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha invalido.");
            return CustomResponse();
        }

        private async Task<ResponseMessage> RegistrarCliente(RegistroUsuarioViewModel model)
        {
            var usuario = await _userManager.FindByEmailAsync(model.Email);
            var usuarioRegistrado = new UsuarioRegistradoIntegrationEvent(Guid.Parse(usuario.Id), model.Nome, model.Email, model.Cpf);

            try
            {
                return await _bus.RequestAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(usuarioRegistrado);
            }
            catch
            {
                await _userManager.DeleteAsync(usuario);
                throw;
            }

        }
    }
}
