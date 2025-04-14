// Models/ManipulacaoStringRequest.cs
public class ManipulacaoStringRequest
{
    public string Texto { get; set; }
}

// Models/ManipulacaoStringResponse.cs
public class ManipulacaoStringResponse
{
    public bool Palindromo { get; set; }
    public Dictionary<char, int> OcorrenciasCaracteres { get; set; }
}