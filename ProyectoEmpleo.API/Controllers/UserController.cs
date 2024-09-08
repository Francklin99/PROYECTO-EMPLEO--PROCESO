using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoEmpleo.API.Utilidad;
using ProyectoEmpleo.BLL.Servicios.Contrato;
using ProyectoEmpleo.DTO;
using System.Security.Claims;

namespace ProyectoEmpleo.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService=userService;
        }



        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var rsp = new ResponseApi<UserDTO>();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();
                rsp.status = true;
                rsp.Value = await _userService.GetUserByIdAsync(int.Parse(userId));
                if (rsp.Value == null)
                    return NotFound();
            }
            catch
            {
                throw;
            }
            return Ok(rsp);
        }
    }
}
