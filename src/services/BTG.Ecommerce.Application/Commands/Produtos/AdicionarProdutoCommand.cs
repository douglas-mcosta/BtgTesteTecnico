using BTG.Core.Messages;
using FluentValidation;

namespace BTG.Ecommerce.Application.Commands.Produtos
{
    public class AdicionarProdutoCommand : Command
    {
        public AdicionarProdutoCommand(string nome, string descricao, bool ativo, decimal valor, string imagem, int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
    }

    public class AdicionarProdutoCommandValidation : AbstractValidator<AdicionarProdutoCommand>
    {

    }
}
