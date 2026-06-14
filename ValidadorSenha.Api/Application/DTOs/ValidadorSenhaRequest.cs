using System.ComponentModel.DataAnnotations;

namespace ValidadorSenha.Api.Application.DTOs
{
    public class ValidadorSenhaRequest
    {
        public string Senha { get; set; } = string.Empty;
    }
}
