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
