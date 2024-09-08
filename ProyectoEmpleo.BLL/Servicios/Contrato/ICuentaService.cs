using ProyectoEmpleo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.BLL.Servicios.Contrato
{
    public interface ICuentaService
    {
        Task<CuentaDTO> RegistrarCuenta(CuentaDTO cuenta);

    }
}
