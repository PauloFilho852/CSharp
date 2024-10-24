using APICatalogo.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Text.Json.Serialization;
using APICatalogo.Services;

namespace APICatalogo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
                        
            //Configura��o e Registro: builder.Services.AddControllers();
            //registra os controladores e servi�os relacionados no cont�iner DI,
            //tornando-os dispon�veis para a aplica��o.
            builder.Services.AddControllers().AddJsonOptions(options=> options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            //Configuration � uma inst�ncia de IConfigurantion.
            //Pegando a connection string do arquivo appsettings.json
            string? sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            //Pegando um valor qualquer do aquivo appsettings.json
            //var valor1 = builder.Configuration["chave1"];
            
            //Inje��o do depend�ncia do DbContext
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlServerConnection));

            //Adiconando um servi�o para inje��o de depend�ncia.
            builder.Services.AddTransient<IMeuServico, MeuServico>();
                        
            //Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //Adiciona servi�os para explorar endpoints da API e configurar o Swagger
            //para gerar a documenta��o da API.Define a vers�o e o t�tulo da documenta��o da API.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Para desabilitar os par�metros FromServices impl�citos.
            //builder.Services.Configure<ApiBehaviorOptions>((options) => { options.DisableImplicitFromServicesParameters = true; });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            //Mapeamento e Roteamento: app.MapControllers();
            //examina esses controladores e mapeia seus m�todos para os caminhos HTTP apropriados,
            //permitindo que a aplica��o responda �s requisi��es feitas aos endpoints definidos.
            app.MapControllers();

            app.Run();
        }
    }
}
