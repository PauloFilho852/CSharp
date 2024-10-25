using APICatalogo.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace APICatalogo.Extensions;

public static class MiddlewareExtensions
{
    public static void UseCustumExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                
				//Atribui um código de status.
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                				
				//Tipo de reposta
				context.Response.ContentType = "application/json";
				
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                
				//Verifica de houve e exeção
				if (contextFeature != null)
                {
                    //Retorna mensagem de erro na resposta HTTP em formato json.
					await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace
                    }.ToString());
                }
            });
        });
    }
}
