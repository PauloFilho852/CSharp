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
            
                        
            //Configuração e Registro: builder.Services.AddControllers();
            //registra os controladores e serviços relacionados no contêiner DI,
            //tornando-os disponíveis para a aplicação.
            builder.Services.AddControllers().AddJsonOptions(options=> options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            //Configuration é uma instância de IConfigurantion.
            //Pegando a connection string do arquivo appsettings.json
            string? sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            //Pegando um valor qualquer do aquivo appsettings.json
            //var valor1 = builder.Configuration["chave1"];
            
            //Injeção do dependência do DbContext
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlServerConnection));

            //Adiconando um serviço para injeção de dependência.
            builder.Services.AddTransient<IMeuServico, MeuServico>();
                        
            //Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //Adiciona serviços para explorar endpoints da API e configurar o Swagger
            //para gerar a documentação da API.Define a versão e o título da documentação da API.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Para desabilitar os parâmetros FromServices implícitos.
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
            //examina esses controladores e mapeia seus métodos para os caminhos HTTP apropriados,
            //permitindo que a aplicação responda às requisições feitas aos endpoints definidos.
            app.MapControllers();

            app.Run();
        }
    }
}
