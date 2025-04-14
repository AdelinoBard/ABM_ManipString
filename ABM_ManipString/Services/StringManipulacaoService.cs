namespace ABM_ManipString.Services;
public class StringManipulacaoService
{
    public ManipulacaoStringResponse AnalisarString(string texto)
    {
        if (texto == null)
        {
            return new ManipulacaoStringResponse
            {
                Palindromo = false,  // String nula NÃO é palíndromo
                OcorrenciasCaracteres = new Dictionary<char, int>()
            };
        }

        if (texto == "")
        {
            return new ManipulacaoStringResponse
            {
                Palindromo = true,  // String vazia é palíndromo
                OcorrenciasCaracteres = new Dictionary<char, int>()
            };
        }

        var ocorrenciasCaracteres = ContarCaracteres(texto);
        bool isPalindromo = VerificarPalindromo(texto);

        return new ManipulacaoStringResponse
        {
            Palindromo = isPalindromo,
            OcorrenciasCaracteres = ocorrenciasCaracteres
        };
    }

    private bool VerificarPalindromo(string texto)
    {
        var textoLimpo = new string(texto.Where(c => !char.IsWhiteSpace(c))
                                        .Select(c => char.ToLower(c))
                                        .ToArray());
        return textoLimpo.SequenceEqual(textoLimpo.Reverse());
    }

    private Dictionary<char, int> ContarCaracteres(string texto)
    {
        return texto.GroupBy(c => char.ToLower(c))
                   .ToDictionary(g => g.Key, g => g.Count());
    }
}