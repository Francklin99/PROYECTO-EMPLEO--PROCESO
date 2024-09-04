using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoEmpleo.API.Utilidad;
using ProyectoEmpleo.BLL.Servicios.Contrato;
using ProyectoEmpleo.DTO;
using ProyectoEmpleo.Model;
using ProyectoEmpleo.Utility;
using System.Reflection.Metadata;

namespace ProyectoEmpleo.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        
        private readonly EncriptService _encriptService;
        private readonly IUserService _iUserService;
        private readonly ICuentaService _cuentaService;

        public AccesoController(EncriptService encriptService, IUserService iUserService, ICuentaService cuentaService)
        {
            _encriptService = encriptService;
            _iUserService = iUserService;
            _cuentaService = cuentaService;
        }
        [HttpPost]
        [Route("RegistrarCuenta")]
        public async Task<ActionResult> RegistrarCuenta(CuentaDTO cuenta)
        {
            var rsp=new ResponseApi<CuentaDTO>();

            try
            {
                rsp.status = true;
                rsp.Value = await _cuentaService.RegistrarCuenta(cuenta);
               
            }
            catch(Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }
            return Ok(rsp);

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO objeto) {
          
            User user_encontrado= await _iUserService.Login(objeto);
            
            if(user_encontrado==null)
            {
                return StatusCode(StatusCodes.Status200OK, new {isSuccess=false,token=""});
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _encriptService.generarJWT(user_encontrado) });
            }
        }


        [HttpGet]
        [Route("ValidarToken")]
        public IActionResult ValidarToken([FromQuery] string token)
        {
            bool respuesta=_encriptService.validarToken(token);
         
            
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
            
        }

    }
}
