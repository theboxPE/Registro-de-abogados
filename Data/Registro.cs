namespace Proyecto_Final.Data
{
    public class Registro
    {
        public class Caso
        {
            public int Id { get; set; }
            public DateTime Fecha { get; set; }
            public List<Cliente>? Clientes { get; set; }
            public int ClienteId { get; set; }
            public string? ClienteNombre { get; set; }
            public string? TipoCaso { get; set; }
            public string? Descripcion { get; set; }
            public double Latitud { get; set; }
            public double Longitud { get; set; }
            public string? AbogadoAsignado { get; set; }
            public string? EstadoCaso { get; set; }
        }

        public class Cliente
        {
            public int Id { get; set; }
            public string? Cedula { get; set; }
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Correo { get; set; }
            public string? Telefono { get; set; }
            public string? Celular { get; set; }
            public string? Direccion { get; set; }
            public string? EstadoCivil { get; set; }
        }
    }
}
