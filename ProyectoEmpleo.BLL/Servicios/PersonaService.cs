using AutoMapper;
using ProyectoEmpleo.BLL.Servicios.Contrato;
using ProyectoEmpleo.DAL.Repositorio.Contrato;
using ProyectoEmpleo.DTO;
using ProyectoEmpleo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.BLL.Servicios
{
    public class PersonaService : IPersonaService
    {
        private readonly IGenericRepository<Person> _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IGenericRepository<Person> personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public  Task<PersonDTO> AddPersona(PersonDTO persona)
        {
            try
            {
                var person = _mapper.Map<Person>(persona);
                _personaRepository.crear(person);
                return Task.FromResult(_mapper.Map<PersonDTO>(person));
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeletePersona(int id)
        {

            try
            {
                var persona = await _personaRepository.obtener(x => x.Id == id);

                if (persona == null)
                {
                    throw new TaskCanceledException("No se encontro la persona");
                }
                bool respuesta = await _personaRepository.eliminar(persona);
                if (!respuesta)
                {
                    throw new TaskCanceledException("No se puede eliminar la persona");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PersonDTO>> GetPersonas()
        {
            try
            {
                var personas =await _personaRepository.consultar();
                return _mapper.Map<List<PersonDTO>>(personas);
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> UpdatePersona(PersonDTO persona)
        {
            throw new NotImplementedException();
        }
    }
}
