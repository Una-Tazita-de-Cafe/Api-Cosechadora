namespace Api_Cosechadora.Modelo.CosechadoraBrocoli
{
    //se declaran las variables que se ocupan para recibir los datos y mandarlos al front para pintae las graficas
    public class MGrafica
    {
        //Datos de entra de la base de datos
        public string? Rancho { get; set; }
        public string? Parcela { get; set; }
        public string? Fecha { get; set; }

        //Datos que se otendran de la variable de Lista
        public List<int>? numeros { get; set;}
        public int CantidadObservada { get; set; }
        public int CantidadEnRango { get; set;}
        public int PorDebajo { get; set; }
        public int PorEncima { get; set; }
    }
}
