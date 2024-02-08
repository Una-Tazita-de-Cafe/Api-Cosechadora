using Api_Cosechadora.Conexion;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;
using System.Data;
using System.Data.SqlClient;
namespace Api_Cosechadora.Datos
{
    public class DDatos
    {
        ConexionBD cn=new ConexionBD();
        public async Task<List<MDatos>> MostrarDatos()
        {
            var lista=new List<MDatos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd=new SqlCommand("select A.idObservacion,B.FechaCorte,D.NombreRancho,E.nombreParcela from Prueba A inner join Corte B on A. idCorte = B.idCorte inner join Cosecha C on B.idCosecha=C.idCosecha inner join Rancho D on C.idRancho = D.idRancho inner join Parcela E on  E.idParcela=C.idParcela", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.Text;
                    using (var item =await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var mdatos= new MDatos();
                            mdatos.IdObservacion = (int)item["idObservacion"];
                            mdatos.Fecha = ((DateTime)item["FechaCorte"]).Date;
                            mdatos.Rancho = (string)item["NombreRancho"];
                            mdatos.Parcela = (string)item["nombreParcela"];
                            lista.Add(mdatos);
                        }
                    }
                }
                
            }
            return lista;
        }
    }
}
