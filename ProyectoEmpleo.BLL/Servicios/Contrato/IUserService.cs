using ProyectoEmpleo.DTO;
using ProyectoEmpleo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.BLL.Servicios.Contrato
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers(); // <1>
        Task<User> AddUser(UserDTO user);
        Task<bool> ModifyUser(UserDTO user);
        Task<bool> DeleteUser(int id);
        Task<User> Login(LoginDTO login);
    }
}
