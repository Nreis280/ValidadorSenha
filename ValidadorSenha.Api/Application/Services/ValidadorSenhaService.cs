using ValidadorSenha.Api.Application.Domain.Interfaces;

namespace ValidadorSenha.Api.Application.Services
{
    public class ValidadorSenhaService : IValidadorSenhaService
    {
        private const int TamanhoMinimo = 9;
        private const string CaracteresEspeciais = "!@#$%^&*()-+";


        public bool SenhaEhValida(string senha)
        {
            return PossuiValor(senha)
                && PossuiTamanhoMinimo(senha)
                && NaoPossuiEspacosEmBranco(senha)
                && PossuiNumero(senha)
                && PossuiLetraMinuscula(senha)
                && PossuiLetraMaiuscula(senha)
                && PossuiCaractereEspecial(senha)
                && NaoPossuiCaracteresRepetidos(senha);
        }

        private static bool PossuiValor(string senha)
        {
            return !string.IsNullOrWhiteSpace(senha);
        }

        private static bool PossuiTamanhoMinimo(string senha)
        {
            return senha.Length >= TamanhoMinimo;
        }

        private static bool NaoPossuiEspacosEmBranco(string senha)
        {
            return !senha.Any(char.IsWhiteSpace);
        }

        private static bool PossuiNumero(string senha)
        {
            return senha.Any(char.IsDigit);
        }

        private static bool PossuiLetraMinuscula(string senha)
        {
            return senha.Any(char.IsLower);
        }

        private static bool PossuiLetraMaiuscula(string senha)
        {
            return senha.Any(char.IsUpper);
        }

        private static bool PossuiCaractereEspecial(string senha)
        {
            return senha.Any(CaracteresEspeciais.Contains);
        }

        private static bool NaoPossuiCaracteresRepetidos(string senha)
        {
            return senha.Distinct().Count() == senha.Length;
        }
    }
}
