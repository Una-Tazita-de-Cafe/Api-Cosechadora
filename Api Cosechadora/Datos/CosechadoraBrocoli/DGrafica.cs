using Api_Cosechadora.Conexion;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Api_Cosechadora.Datos
{
   
    public class DGrafica
    {
        ConexionBD cn = new ConexionBD();
        public async Task <ActionResult<List<MGrafica>>> MostrarGrafica(int i)
        {
            var lista = new List<MGrafica>();
            using (var sql=new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd=new SqlCommand("select B.FechaCorte,A.ListaTamano,D.NombreRancho,E.nombreParcela, A.CantidadObservada, A.CantidadCortada,A.CantidadPorEncima,A.CantidadPorDebajo from Observacion A inner join Corte B on A. idCorte = B.idCorte inner join Cosecha C on B.idCosecha=C.idCosecha inner join Rancho D on C.idRancho = D.idRancho inner join Parcela E on  E.idParcela=C.idParcela where A.idObservacion=@numero", sql))
                {
                    cmd.Parameters.AddWithValue("@numero", i);
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.Text;
                    using ( var item =await cmd.ExecuteReaderAsync())
                    {
                        await item.ReadAsync();
                        string[] num;
                        var datos = new MGrafica();
                        datos.Fecha = ((DateTime)item["FechaCorte"]).ToString("d");
                        num = ((string)item["ListaTamano"]).Trim('[', ']').Split(",");
                        datos.numeros = num.Select(e => int.Parse(e)).ToList();
                        datos.Rancho = (string)item["NombreRancho"];
                        datos.Parcela = (string)item["nombreParcela"];
                        datos.CantidadObservada = (int)item["CantidadObservada"];
                        datos.CantidadEnRango = (int)item["CantidadCortada"];
                        datos.PorEncima = (int)item["CantidadPorEncima"];
                        datos.PorDebajo = (int)item["CantidadPorDebajo"];
                        lista.Add(datos);                           
                    }
                }
            } 
            return lista;
        }
    }
}
