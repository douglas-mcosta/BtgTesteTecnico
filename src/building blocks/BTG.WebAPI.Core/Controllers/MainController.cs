using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ValidationResult = FluentValidation.Results.ValidationResult;
using BTG.Core.Communication;
namespace BTG.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> {
                { "Mensagens", erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(s => s.Errors);

            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult response)
        {
            ResponsePossuiErros(response);
            return CustomResponse();
        }

        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response is null || !response.Errors.Mensagens.Any()) return false;

            response.Errors.Mensagens.ForEach(erro => AdicionarErroProcessamento(erro));

            return true;
        }

        protected bool OperacaoValida()
        {
            return !erros.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            erros.Add(erro);
        }

        protected void AdicionarErroProcessamento(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(e => erros.Add(e.ErrorMessage));
        }

        protected void LimparErrosProcessamento()
        {
            erros.Clear();
        }
    }
}
