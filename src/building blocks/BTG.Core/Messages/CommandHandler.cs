using BTG.Core.DomainObjects.Data;
using FluentValidation.Results;

namespace BTG.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> SaveChanges(IUnitOfWork unitOfWork)
        {
            var sucesso = await unitOfWork.Commit();
            if (!sucesso)
            {
                AdicionarErro("Houve um erro ao persistir os dados.");
            }
            return ValidationResult;
        }
    }
}
