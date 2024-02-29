using Api_Cosechadora.Conexion;
using System.Data.SqlClient;
using System.Data;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;

namespace Api_Cosechadora.Datos.Papainador
{
    public class DPapas
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MDatos>> MostrarDatos()
        {
            var lista = new List<MDatos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("select A.idPruebaPapas,B.InicioCosecha,D.NombreRancho,c.nombreParcela from PruebaPapas A inner join Cosecha B on A.idCosecha=B.idCosecha inner join Parcela C on  B.idParcela=C.idParcela inner join Rancho D on B.idRancho= D.idRancho ", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.Text;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mdatos = new MDatos();
                            mdatos.IdObservacion = (int)item["idPruebaPapas"];
                            mdatos.Fecha = ((DateTime)item["InicioCosecha"]).ToString("d");
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
