using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracoesController : ControllerBase
    {
        
        //Utilizado para ler o arquivo de configurações appsettings.json. Os dados do aquivos de configurações
        //appsetting.Development.json (ou outro, dependendo do perfil executado, constante no arquivo launchSettings.json)
        //sobrepõe dados de identificação iguais no appsettings.json.
        //
        private readonly IConfiguration _configuration;
        public ConfiguracoesController(IConfiguration configuration)
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
    }
}
