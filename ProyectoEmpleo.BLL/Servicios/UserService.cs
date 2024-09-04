using AutoMapper;
using ProyectoEmpleo.BLL.Servicios.Contrato;
using ProyectoEmpleo.DAL.Repositorio.Contrato;
using ProyectoEmpleo.DTO;
using ProyectoEmpleo.Model;
using ProyectoEmpleo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.BLL.Servicios
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly EncriptService _encriptService;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper, EncriptService encriptService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encriptService = encriptService;
        }

        public async Task<User> AddUser(UserDTO user)
        {
            var usermodelo=new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = _encriptService.encriptarSHA256(user.PasswordHash)
            };
            

            try
            {
                var existEmail=await _userRepository.obtener(x=>x.Email==user.Email);
                if (existEmail==null)
                {
                    var userCreado = await _userRepository.crear(_mapper.Map<User>(usermodelo));

                    if (userCreado.Id==0)
                        throw new TaskCanceledException("No se puede crear");

                    return userCreado;
                }
                else
                {
                    throw new TaskCanceledException("Email ya existe");
                }
                
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(LoginDTO login)
        {
            var usuarioencontrado=await _userRepository.obtener(x=>x.Email==login.Email && x.PasswordHash==_encriptService.encriptarSHA256(login.PasswordHash));

            if (usuarioencontrado != null) // Si el usuario es encontrado
            {
                return usuarioencontrado; // Devuelve el usuario encontrado
            }
            else
            {
                return null!; // Devuelve null si no se encuentra el usuario
            }
        }

        public Task<bool> ModifyUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

      
    }
}
