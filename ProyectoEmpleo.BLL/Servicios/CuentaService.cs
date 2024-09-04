using AutoMapper;
using ProyectoEmpleo.BLL.Servicios.Contrato;
using ProyectoEmpleo.DAL.Repositorio.Contrato;
using ProyectoEmpleo.DTO;
using ProyectoEmpleo.Model;
using ProyectoEmpleo.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.BLL.Servicios
{
    public class CuentaService : ICuentaService
    {
        private readonly IGenericRepository<Person> _personRepository;
        private IUserService _iUserService;
        private readonly IMapper _mapper;

        public CuentaService(IGenericRepository<Person> personRepository,IUserService iUserService,IMapper mapper)
        {
            _personRepository = personRepository;
            _iUserService = iUserService;
            _mapper = mapper;
        }
         
        public async Task<CuentaDTO> RegistrarCuenta(CuentaDTO cuenta)
        {
                 var usermodel = await _iUserService.AddUser(cuenta.Usuario);

            try
            {
                if (usermodel != null)
                {
                    cuenta.Persona.UserId = usermodel.Id;
                    var personmodel = await _personRepository.crear(_mapper.Map<Person>(cuenta.Persona));
                }
            }
            catch
            {
                new TaskCanceledException("No se puede registrar la cuenta");
            }      
                return cuenta;     
        }
    }
}
