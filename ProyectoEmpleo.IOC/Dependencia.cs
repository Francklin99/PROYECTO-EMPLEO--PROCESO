using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoEmpleo.BLL.Servicios;
using ProyectoEmpleo.BLL.Servicios.Contrato;
using ProyectoEmpleo.DAL.DBContext;
using ProyectoEmpleo.DAL.Repositorio;
using ProyectoEmpleo.DAL.Repositorio.Contrato;
using ProyectoEmpleo.Model;
using ProyectoEmpleo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoEmpleo.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbEmpleoContext>(option=>
            option.UseSqlServer(configuration.GetConnectionString("CadenaSQL")));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IPersonaService, PersonaService>(); //<-->
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICuentaService, CuentaService>();

            //servicios adicionales 
            services.AddSingleton<EncriptService>();
          
           
        }
    }

}
