using Api_Cosechadora.Conexion;
using Api_Cosechadora.Modelo.CosechadoraApp;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Api_Cosechadora.Datos.CosechadoraApp
{
    public class DGrafica_App_CosechadoraApp
    {
        ConexionBD cn = new ConexionBD();
        public async Task<ActionResult<List<MGraficas_App_CosechadoraApp>>> MostrarGraficaApp(int i)
        {
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int v4 = 0;
            var lista = new List<MGraficas_App_CosechadoraApp>();
            using (var sql =new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("select Menor14,Cant_14,Cant_15,Cant_16,Cant_17,Cant_18,Cant_19,Cant_20,Cant_21,Cant_22,Cant_23,Cant_24,Cant_25,Cant_26,Cant_27,Cant_28,Cant_29,Cant_30, Mayor30, CantidadObservada, CantidadCortada,CantidadPorDebajo, CantidadPorEncima from Prueba where idObservacion=@numero", sql))
                {
                    cmd.Parameters.AddWithValue("@numero", i);
                    await sql.OpenAsync();
                    cmd.CommandType=CommandType.Text;
                    using (var item =await cmd.ExecuteReaderAsync())
                    {
                        await item.ReadAsync();
                        var datos =new MGraficas_App_CosechadoraApp();
                        int[] num = { (int)item["Menor14"], (int)item["Cant_14"], (int)item["Cant_15"],
                                      (int)item["Cant_16"], (int)item["Cant_17"], (int)item["Cant_18"], (int)item["Cant_19"], (int)item["Cant_20"],(int)item["Cant_21"],(int)item["Cant_22"],
                                      (int)item["Cant_23"],(int)item["Cant_24"],(int)item["Cant_25"],(int)item["Cant_26"],(int)item["Cant_27"],(int)item["Cant_28"],(int)item["Cant_29"],(int)item["Cant_30"],(int)item["Mayor30"] };
                        datos.numeros = num.ToList();
                        v1=(int)item["CantidadObservada"];
                        v2=(int)item["CantidadCortada"];
                        v3=(int)item["CantidadPorEncima"];
                        v4=(int)item["CantidadPorDebajo"];
                        datos.CantidadObservada = v1;
                        datos.CantidadEnRango = v2; 
                        datos.PorEncima = v3;
                        datos.PorDebajo = v4;
                        datos.porcentaje1 = Porcentaje(v1!=0? v1:1, v2);
                        datos.porcentaje2 = Porcentaje(v1!=0? v1:1, v3);
                        datos.porcentaje3 = Porcentaje(v1!=0? v1:1, v4);

                        lista.Add(datos);
                    }
                }
            }
            return lista;
        }
        public double Porcentaje(double CantidadObservada, double dato)
        {
            return (double)Math.Round(dato / CantidadObservada, 2)*100;
        }
    }

    
}
