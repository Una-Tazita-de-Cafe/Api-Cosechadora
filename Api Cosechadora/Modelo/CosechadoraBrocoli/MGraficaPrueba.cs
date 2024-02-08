namespace Api_Cosechadora.Modelo.CosechadoraBrocoli

{
    public class MGraficaPrueba
    {
        public string? Rancho { get; set; }
        public string? Parcela { get; set; }
        public DateTime Fecha { get; set; }

        public int CantidadObservada { get; set; }
        public int CantidadCortada { get; set; }
        public int PorEncima { get; set; }
        public int PorDebajo { get; set; }
        public List<int>? numeros { get; set; }
    }
}
