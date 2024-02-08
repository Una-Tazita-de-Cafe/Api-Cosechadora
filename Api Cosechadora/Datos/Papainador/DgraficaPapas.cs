
using Api_Cosechadora.Conexion;
using Api_Cosechadora.Modelo.Papainador;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Api_Cosechadora.Datos
{
    public class DgraficaPapas
    {
        ConexionBD cn=new ConexionBD();
        public async Task<ActionResult<List<MGraficaPapa>>> MostrarGraficaPapas(int i)
        {
            var lista=new List<MGraficaPapa>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("select A.CantidadObservada,A.Sexta,A.Quinta,A.Cuarta,A.Tercera,A.Segunda,A.Primera,A.Suprema, B.InicioCosecha, B.FinCosecha, C.nombreParcela, D.NombreRancho from PruebaPapas A inner join Cosecha B on A.idCosecha = B.idCosecha inner join Parcela C on B.idParcela=C.idParcela inner join Rancho D on B.idRancho=D.idRancho where B.idCosecha=@numero ",sql)) 
                {
                    cmd.Parameters.AddWithValue("@numero", i);
                    await sql.OpenAsync();
                    cmd.CommandType=CommandType.Text;
                    using(var item =await cmd.ExecuteReaderAsync())
                    {
                        await item.ReadAsync();
                        var datos = new MGraficaPapa();
                        datos.CantidadObservada = (int)item["CantidadObservada"];
                        int[] num = { (int)item["Sexta"], (int)item["Quinta"], (int)item["Cuarta"],
                                      (int)item["Tercera"],(int)item["Segunda"],(int)item["Primera"],
                                      (int)item["Suprema"]};
                        datos.numeros=num.ToList();
                        datos.FechaI = (DateTime)item["InicioCosecha"];
                        datos.FechaF = (DateTime)item["FinCosecha"];
                        datos.Parcela = (string)item["nombreParcela"];
                        datos.Rancho = (string)item["nombreRancho"];
                        lista.Add(datos);
                    }
                }
            }
            return lista;
        }
            
    }
}
