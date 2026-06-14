using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorSenha.Api.Application.Services.Impl;
using Xunit;

namespace ValidadorSenha.UnitTests.Services
{
    public class ValidadorSenhaServiceTests
    {
        private readonly ValidadorSenhaService _service;

        public ValidadorSenhaServiceTests()
        {
            _service = new ValidadorSenhaService();
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("aa", false)]
        [InlineData("ab", false)]
        [InlineData("AAAbbbCc", false)]
        [InlineData("AbTp9!foo", false)]
        [InlineData("AbTp9!foA", false)]
        [InlineData("AbTp9 fok", false)]
        [InlineData("AbTp9!fok", true)]
        public void SenhaEhValida_DeveRetornarResultadoConformeRegrasDeValidacao(
            string senha,
            bool resultadoEsperado)
        {
            var resultado = _service.SenhaEhValida(senha);

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
