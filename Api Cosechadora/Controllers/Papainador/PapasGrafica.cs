using Api_Cosechadora.Datos;
using Api_Cosechadora.Modelo.Papainador;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cosechadora.Controllers
{
    [ApiController]
    [Route("api/PapaGrafica")]
    public class PapasGrafica
    {
        [HttpGet("{id}")]
        public async Task <ActionResult<List<MGraficaPapa>>> Get(int id)
        {
            try
            {
                var funcion = new DgraficaPapas();
                var lista = await funcion.MostrarGraficaPapas(id);
                return lista;
            }catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}
