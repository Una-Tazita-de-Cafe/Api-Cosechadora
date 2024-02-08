
using Api_Cosechadora.Datos.Papainador;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cosechadora.Controllers.Papainador
{
    [ApiController]
    [Route("api/DatosPapas")]
    public class DatosPapasControllers
    {
        [HttpGet]
        public async Task<ActionResult<List<MDatos>>> Get()
        {
            var funcion = new DPapas();
            var lista = await funcion.MostrarDatos();
            return lista;
        }
    }
}
