namespace ValidadorSenha.Api.Application.Domain.Interfaces
{
    public interface IValidadorSenhaService
    {
        bool SenhaEhValida(string password);
    }
}
