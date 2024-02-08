using Api_Cosechadora.Datos;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cosechadora.Controllers
{
    [ApiController]
    [Route("api/datos")]
    public class DatosController
    {
        [HttpGet]
        public async Task <ActionResult<List<MDatos>>> Get()
        {
            var funcion = new DDatos();
            var lista = await funcion.MostrarDatos();
            return lista;
        }
    }
    
}
