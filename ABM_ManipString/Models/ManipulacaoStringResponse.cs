namespace ABM_ManipString.Models;

public class ManipulacaoStringResponse
{
    public bool Palindromo { get; set; }
    public Dictionary<char, int> OcorrenciasCaracteres { get; set; } = new();
}