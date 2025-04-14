## Código

### ABM_ManipString/Program.cs

```c#
using ABM_ManipString.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container DI
builder.Services.AddScoped<StringManipulacaoService>();
builder.Services.AddControllers();  // Necessário para suportar controllers MVC

// Configura os serviços necessários para controladores com views
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configura as rotas para controladores com views
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

```

### ABM_ManipString/Controllers/ManipulacaoStringController.cs

```c#
using Microsoft.AspNetCore.Mvc;
using ABM_ManipString.Models;
using ABM_ManipString.Services;

namespace ABM_ManipString.Controllers
{
    /// <summary>
    /// Controlador para exibição de status.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Exibe a página de status para informar que o programa está rodando.
        /// </summary>
        /// <returns>View de status</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }

    /// <summary>
    /// Controlador para manipulação de strings.
    /// </summary>
    [ApiController]
    [Route("api/manipulacao-string")]
    public class ManipulacaoStringController : ControllerBase
    {
        private readonly StringManipulacaoService _service;

        /// <summary>
        /// Construtor que injeta o serviço de manipulação de strings.
        /// </summary>
        /// <param name="service">Serviço de manipulação de strings</param>
        public ManipulacaoStringController(StringManipulacaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Endpoint POST para manipular uma string recebida na requisição.
        /// </summary>
        /// <param name="request">Objeto da requisição contendo o texto a ser analisado</param>
        /// <returns>Resultado da análise da string</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ManipulacaoStringRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Texto))
            {
                return Ok(new ManipulacaoStringResponse
                {
                    Palindromo = false,
                    OcorrenciasCaracteres = new Dictionary<char, int>()
                });
            }

            var response = _service.AnalisarString(request.Texto);
            return Ok(response);
        }
    }
}
```

### ABM_ManipString/Models/ManipulacaoStringRequest.cs

```c#
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
```

### ABM_ManipString/Models/ManipulacaoStringResponse.cs

```c#
namespace ABM_ManipString.Models;

public class ManipulacaoStringResponse
{
    public bool Palindromo { get; set; }
    public Dictionary<char, int> OcorrenciasCaracteres { get; set; } = new();
}
```

### ABM_ManipString/Services/StringManipulacaoService.cs

```c#
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
```

### ABM_ManipString/View/Home/Index.cshtml

```html
@{
    ViewData["Title"] = "Status do Programa";
}

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"]</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f4f4f4;
        }
        .status-container {
            text-align: center;
            background: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #2c3e50;
        }
        p {
            color: #7f8c8d;
        }
    </style>
</head>
<body>
    <div class="status-container">
        <h1>O programa está em execução!</h1>
        <p>Parabéns, sua aplicação está rodando corretamente.</p>
        <p><strong>Data e Hora:</strong> @DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")</p>
    </div>
</body>
</html>
```

### ABM_ManipString/Properties/launchSettings.json
```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:5000",
      "sslPort": 0
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "home/index",
      "applicationUrl": "http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```