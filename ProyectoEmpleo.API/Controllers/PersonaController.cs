using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEmpleo.Model;
using ProyectoEmpleo.DAL.DBContext;
using ProyectoEmpleo.BLL.Servicios.Contrato;
using ProyectoEmpleo.API.Utilidad;
using ProyectoEmpleo.DTO;
using Microsoft.AspNetCore.Authorization;
namespace ProyectoEmpleo.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
           _personaService = personaService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista()
        {
            var rsp=new ResponseApi<List<PersonDTO>>();
            try
            {
                rsp.status=true;
                rsp.Value=await _personaService.GetPersonas();
             
            }
            catch (Exception ex)
            {
                rsp.status=false;
                rsp.message=ex.Message;
               
            }
            return Ok(rsp);
        }

    }
}
