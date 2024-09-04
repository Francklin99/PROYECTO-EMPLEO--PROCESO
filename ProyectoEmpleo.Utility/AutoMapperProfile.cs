using AutoMapper;
using ProyectoEmpleo.DTO;
using ProyectoEmpleo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.Utility
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<,>().ReverseMap();
            #region Personas
            // Mapeo de Person a PersonDTO
            CreateMap<Person, PersonDTO>()
                .ForMember(destino => destino.DateOfBirth, opt => opt.MapFrom(origen => origen.DateOfBirth.HasValue ? origen.DateOfBirth.Value.ToString("yyyy-MM-dd") : null));

            // Mapeo de PersonDTO a Person
            CreateMap<PersonDTO, Person>()
                .ForMember(destino => destino.DateOfBirth, opt => opt.MapFrom(origen => string.IsNullOrEmpty(origen.DateOfBirth) ? (DateOnly?)null : DateOnly.Parse(origen.DateOfBirth)))
                .ForMember(destino => destino.Id, opt => opt.Ignore())
                .ForMember(destino => destino.CreatedAt, opt => opt.Ignore())
                .ForMember(destino => destino.UpdatedAt, opt => opt.Ignore())
                .ForMember(destino => destino.User, opt => opt.Ignore());

            #endregion Personas

            #region User
            CreateMap<UserDTO, User>().ReverseMap();     
            #endregion User



        }
    }
}
