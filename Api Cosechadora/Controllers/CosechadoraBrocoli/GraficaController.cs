using Api_Cosechadora.Datos;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cosechadora.Controllers
{
    [ApiController]
    [Route("api/grafica")]
    public class GraficaController
    {
        [HttpGet("{id}")]
        public async Task <ActionResult<List<MGrafica>>> Get(int id)
        {
            try
            {
                var funcion = new DGrafica();
                var lista = await funcion.MostrarGrafica(id);
                return lista;
            }catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
           
        }
    }
}
