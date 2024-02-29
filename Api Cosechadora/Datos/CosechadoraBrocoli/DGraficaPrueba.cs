using Api_Cosechadora.Conexion;
using Api_Cosechadora.Modelo.CosechadoraBrocoli;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Api_Cosechadora.Datos
{
    public class DGraficaPrueba
    {
        ConexionBD cn =new ConexionBD();
        public async Task <ActionResult<List<MGrafica>>> MostrarGrafica(int i)
        {
            var lista = new List<MGrafica>();
            using (var sql =new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd=new SqlCommand("select B.FechaCorte,A.Menor14,A.Cant_14,A.Cant_15,A.Cant_16,A.Cant_17,A.Cant_18,A.Cant_19,A.Cant_20,A.Cant_21,A.Cant_22,A.Cant_23,A.Cant_24,A.Cant_25,A.Cant_26,A.Cant_27,A.Cant_28,A.Cant_29,A.Cant_30,A.Mayor30,D.NombreRancho,E.nombreParcela, A.CantidadObservada, A.CantidadCortada,A.CantidadPorEncima,A.CantidadPorDebajo from Prueba A inner join Corte B on A. idCorte = B.idCorte inner join Cosecha C on B.idCosecha=C.idCosecha inner join Rancho D on C.idRancho = D.idRancho inner join Parcela E on  E.idParcela=C.idParcela where A.idObservacion=@numero",sql))
                {
                    cmd.Parameters.AddWithValue("@numero", i);
                    await sql.OpenAsync();
                    cmd.CommandType=CommandType.Text;
                    using(var item =await  cmd.ExecuteReaderAsync())
                    {
                        await item.ReadAsync();
                        var datos = new MGrafica();
                        datos.Fecha = ((DateTime)item["FechaCorte"]).ToString("d");
                        int[] value = {
                            (int)item["Menor14"],
                            (int)item["Cant_14"],
                            (int)item["Cant_15"],
                            (int)item["Cant_16"],
                            (int)item["Cant_17"],
                            (int)item["Cant_18"],
                            (int)item["Cant_19"],
                            (int)item["Cant_20"],
                            (int)item["Cant_21"],
                            (int)item["Cant_22"],
                            (int)item["Cant_23"],
                            (int)item["Cant_24"],
                            (int)item["Cant_25"],
                            (int)item["Cant_26"],
                            (int)item["Cant_27"],
                            (int)item["Cant_28"],
                            (int)item["Cant_29"],
                            (int)item["Cant_30"],
                            (int)item["Mayor30"]
                        };
                        int[] num = value;
                        datos.numeros = num.ToList();
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
