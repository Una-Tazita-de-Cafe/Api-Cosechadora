using Api_Cosechadora.Datos;
using Api_Cosechadora.Datos.CosechadoraApp;
using Api_Cosechadora.Modelo.CosechadoraApp;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cosechadora.Controllers.CosechadoraApp
{
        [ApiController]
        [Route("api/AplicasionMovil")]
    public class Grafica_App_CosechadoraApp_Controller
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MGraficas_App_CosechadoraApp>>> Get(int id)
        {
            try
            {
                var funcion = new DGrafica_App_CosechadoraApp();
                var lista = await funcion.MostrarGraficaApp(id);
                return lista;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}
