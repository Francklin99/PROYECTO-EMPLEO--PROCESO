using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoEmpleo.DTO;
using ProyectoEmpleo.Model;

namespace ProyectoEmpleo.BLL.Servicios.Contrato
{
    public interface IPersonaService
    {
        Task<List<PersonDTO>> GetPersonas();
        Task<PersonDTO> AddPersona(PersonDTO persona);
        Task<bool> UpdatePersona(PersonDTO persona);
        Task<bool> DeletePersona(int id);
    }
    
}
