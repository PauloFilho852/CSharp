using APICatalogo.Filters;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Models;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestesController : ControllerBase
    {
        
        //Utilizado para ler o arquivo de configurações appsettings.json. Os dados do aquivos de configurações
        //appsetting.Development.json (ou outro, dependendo do perfil executado, constante no arquivo launchSettings.json)
        //sobrepõe dados de identificação iguais no appsettings.json.
        //
        private readonly IConfiguration _configuration;
        public TestesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            var valor1 = _configuration["chave1"];
            var valor2 = _configuration["chave2"];

            return $"Valor1: {valor1}. Valor2: {valor2}";
        }

        [HttpGet("Erro")]
        public string GetError()
        {
            throw new Exception("Minha mensagem de erro personalizado");
        }

        [HttpGet("logfilter")]
        [ServiceFilter(typeof(LogActionFilter))] // Filtro personalizado a nível do método da Action
        public ActionResult<Categoria> GetLog()
        {
            Categoria category = new()
            {
                Nome = "Nome da Categoria",
                ImagemUrl = "Imagem Url",
                CategoriaId = 4,
            };
            
            return category;
        }
    }
}
