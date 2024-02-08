using Api_Cosechadora.Datos;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cosechadora.Controllers
{
    [ApiController]
    [Route("api/a")]
    public class PuebaGrafica
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MGrafica>>> Get(int id)
        {
            try
            {
                var funcion = new DGraficaPrueba();
                var lista = await funcion.MostrarGrafica(id);
                return lista;
            }catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
