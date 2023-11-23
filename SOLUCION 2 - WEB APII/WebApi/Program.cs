
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Servicios;
using WebApp;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DbContext, MiContexto>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConection"));
            });


            builder.Services.AddScoped(typeof(IRepositorioEspecie), typeof(RepositorioEspecie));

            builder.Services.AddScoped(typeof(IServicioEspecie), typeof(ServicioEspecie));

            builder.Services.AddScoped(typeof(IRepositorioUsuario), typeof(RepositorioUsuario));

            builder.Services.AddScoped(typeof(IServicioUsuario), typeof(ServicioUsuario));

            builder.Services.AddScoped(typeof(IRepositorioEcosistema), typeof(RepositorioEcosistema));

            builder.Services.AddScoped(typeof(IServicioEcosistema), typeof(ServicioEcosistema));

            builder.Services.AddScoped(typeof(IServicioAmenaza), typeof(ServicioAmenaza));

            builder.Services.AddScoped(typeof(IRepositorioAmenaza), typeof(RepositorioAmenaza));

            builder.Services.AddScoped(typeof(IRepositorioPais), typeof(RepositorioPais));

            builder.Services.AddScoped(typeof(IServicioPais), typeof(ServicioPais));

            builder.Services.AddScoped(typeof(IRepositorioEstadoDeConservacion), typeof(RepositorioEstadoDeConservacion));

            builder.Services.AddScoped(typeof(IServicioEstadoDeConservacion), typeof(ServicioEstadoDeConservacion));

            builder.Services.AddScoped(typeof(IRepositorioEcosistemaAmenaza), typeof(RepositorioEcosistemaAmenaza));

            builder.Services.AddScoped(typeof(IServicioEcosistemaEspecie), typeof(ServicioEcosistemaEspecie));

            builder.Services.AddScoped(typeof(IRepositorioEcosistemaEspecie), typeof(RepositorioEcosistemaEspecie));

            builder.Services.AddScoped(typeof(IRepositorioEspecieAmenaza), typeof(RepositorioEspecieAmenaza));

            builder.Services.AddScoped(typeof(IRepositorioUbicacionGeografica), typeof(RepositorioUbicacionGeografica));

            builder.Services.AddScoped(typeof(IServicioUbicacionGeografica), typeof(ServicioUbicacionGeografica));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}