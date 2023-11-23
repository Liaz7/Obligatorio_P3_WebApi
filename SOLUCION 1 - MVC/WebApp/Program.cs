using Microsoft.EntityFrameworkCore;
using Servicios;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authentication;
using System.Numerics;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DbContext, MiContexto>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConection"));
            });

            builder.Services.AddScoped<IRestContext<Usuario>>(provider => new RestContext<Usuario>(builder.Configuration.GetConnectionString("UsuarioUrl")));
            // builder.Services.AddScoped<IRestContext<Ecosistema>>(provider => new RestContext<Ecosistema>(builder.Configuration.GetConnectionString("ecosistemasUrl")));
            builder.Services.AddScoped<IRestContextEcosistema>(provider => new RestContextEcosistema(builder.Configuration.GetConnectionString("EcosistemaUrl")));
            builder.Services.AddScoped<IRestContext<Amenaza>>(provider => new RestContext<Amenaza>(builder.Configuration.GetConnectionString("EcosistemaUrl")));
            builder.Services.AddScoped<IRestContext<Especie>>(provider => new RestContext<Especie>(builder.Configuration.GetConnectionString("EcosistemaUrl")));
            builder.Services.AddScoped<IRestContext<Pais>>(provider => new RestContext<Pais>(builder.Configuration.GetConnectionString("EcosistemaUrl")));
            builder.Services.AddScoped<IRestContext<EstadoDeConservacion>>(provider => new RestContext<EstadoDeConservacion>(builder.Configuration.GetConnectionString("EcosistemaUrl")));
            builder.Services.AddScoped<IRestContext<Especie>>(provider => new RestContext<Especie>(builder.Configuration.GetConnectionString("EspecieUrl")));
            builder.Services.AddScoped<IRestContext<UbicacionGeografica>>(provider => new RestContext<UbicacionGeografica>(builder.Configuration.GetConnectionString("EcosistemaUrl")));
            /*builder.Services.AddScoped<IRestContext<Planta>>(provider => new RestContext<Planta>(builder.Configuration.GetConnectionString("PlantaUrl")));*/
            // builder.Services.AddScoped<IRestContextLogin>(provider => new RestContextLogin(builder.Configuration.GetConnectionString("UsuarioUrl")));

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


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

           // app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}