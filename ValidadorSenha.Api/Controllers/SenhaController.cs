using Microsoft.AspNetCore.Mvc;
using ValidadorSenha.Api.Application.DTOs;
using ValidadorSenha.Api.Application.Services;

namespace ValidadorSenha.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SenhaController : ControllerBase
    {
        private readonly IValidadorSenhaService _validadorSenhaService;

        public SenhaController(IValidadorSenhaService validadorSenhaService)
        {
            _validadorSenhaService = validadorSenhaService;
        }


        [HttpPost("validar")]
        [ProducesResponseType(typeof(ValidadorSenhaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ValidarSenha(
           [FromBody] ValidadorSenhaRequest request)
        {
            var senhaValida = _validadorSenhaService
                .SenhaEhValida(request.Senha);

            var response = new ValidadorSenhaResponse
            {
                SenhaValida = senhaValida
            };

            return Ok(response);
        }
    }
}
