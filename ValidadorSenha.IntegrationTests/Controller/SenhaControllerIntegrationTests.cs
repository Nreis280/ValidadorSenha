using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorSenha.IntegrationTests.Controller
{
    public class SenhaControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public SenhaControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("AbTp9!fok", true)]
        [InlineData("", false)]
        [InlineData("aa", false)]
        [InlineData("ab", false)]
        [InlineData("AAAbbbCc", false)]
        [InlineData("AbTp9!foo", false)]
        [InlineData("AbTp9!foA", false)]
        [InlineData("AbTp9 fok", false)]
        [InlineData("AbTp9!fo_", false)]
        [InlineData("abtp9!fok", false)]
        [InlineData("ABTP9!FOK", false)]
        [InlineData("AbTp!fokA", false)]
        [InlineData("AbTp9fokA", false)]
        public async Task ValidarSenha_DeveRetornarResultadoEsperado(
            string senha,
            bool resultadoEsperado)
        {
            var request = new
            {
                senha
            };

            var response = await _client.PostAsJsonAsync("/api/senha/validar", request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<ValidarSenhaResponse>();

            Assert.NotNull(result);
            Assert.Equal(resultadoEsperado, result!.SenhaValida);
        }

        private class ValidarSenhaResponse
        {
            public bool SenhaValida { get; set; }
        }
    }
}
