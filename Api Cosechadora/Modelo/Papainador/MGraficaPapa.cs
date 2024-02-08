namespace Api_Cosechadora.Modelo.Papainador
{
    public class MGraficaPapa
    {
        public string? Rancho { get; set; }
        public string? Parcela { get; set; }
        public DateTime FechaI { get; set; }
        public DateTime FechaF { get; set; }
        public int CantidadObservada { get; set; }
    
        public List<int>? numeros { get; set; }
    }
}
