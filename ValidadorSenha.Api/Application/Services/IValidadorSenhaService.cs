namespace ValidadorSenha.Api.Application.Services
{
    public interface IValidadorSenhaService
    {
        bool SenhaEhValida(string password);
    }
}
