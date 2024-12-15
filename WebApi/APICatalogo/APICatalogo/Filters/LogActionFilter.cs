using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;

namespace APICatalogo.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }
                        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Executa antes da execução da Action
            _logger.LogInformation("Executando - OnActionExecuting"); //Exibe no console e na janela "Saída" do Visual Studio
            _logger.LogInformation("-------------------------------");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
            _logger.LogInformation("-------------------------------");

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Executa depois da excução da Action
            _logger.LogInformation("Executando - OnActionExecuted");
            _logger.LogInformation("-------------------------------");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"Satus Code: {context.HttpContext.Response.StatusCode}");
            _logger.LogInformation("-------------------------------");

            Console.WriteLine("Ação concluída: " + context.ActionDescriptor.DisplayName); //Exibe no console
        }
    }
}
