using System.ComponentModel.DataAnnotations;

namespace ValidadorSenha.Api.Application.DTOs
{
    public class ValidadorSenhaRequest
    {
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }   
    }
}
