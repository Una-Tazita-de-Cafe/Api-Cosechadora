namespace Api_Cosechadora.Conexion
{
    public class ConexionBD
    {
        private string connectionString = string.Empty;
        public ConexionBD()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = builder.GetSection("ConnectionStrings:conexionMaestra").Value;
        }
        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
