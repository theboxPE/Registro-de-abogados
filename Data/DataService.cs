using Newtonsoft.Json;
using static Proyecto_Final.Data.Registro;
using Formatting = Newtonsoft.Json.Formatting;

namespace Proyecto_Final.Data
{
    public class DataService
    {
        private readonly string datax;

        public DataService()
        {
            datax = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/datax");

            if (!Directory.Exists(datax))
            {
                Directory.CreateDirectory(datax);
            }
        }

        public List<Cliente> GetClientes()
        {
            var clientes = LoadData<List<Cliente>>("clientes.json") ?? new List<Cliente>();
            return clientes;
        }

        public Cliente GetClienteById(int clienteId)
        {
            var clientes = GetClientes();
            return clientes.FirstOrDefault(c => c.Id == clienteId)!;
        }

        public void AddCliente(Cliente cliente)
        {
            var clientes = GetClientes();
            cliente.Id = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1;
            clientes.Add(cliente);
            SaveData("cliente.json", clientes);
        }

        public void UpdateCliente(Cliente cliente)
        {
            var clientes = GetClientes();
            var existingCliente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.Cedula = cliente.Cedula;
                existingCliente.Nombre = cliente.Nombre;
                existingCliente.Apellido = cliente.Apellido;
                existingCliente.Correo = cliente.Correo;
                existingCliente.Telefono = cliente.Telefono;
                existingCliente.Celular = cliente.Celular;
                existingCliente.Direccion = cliente.Direccion;
                existingCliente.EstadoCivil = cliente.EstadoCivil;
                SaveData("cliente.json", clientes);
            }
        }

        public void DeleteCliente(int clienteId)
        {
            var clientes = GetClientes();
            var clienteToDelete = clientes.FirstOrDefault(c => c.Id == clienteId);
            if (clienteToDelete != null)
            {
                clientes.Remove(clienteToDelete);
                SaveData("cliente.json", clientes);
            }
        }

        private T LoadData<T>(string fileName)
        {
            var filePath = Path.Combine(datax, fileName);
            try
            {
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<T>(jsonData)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde {filePath}: {ex.Message}");
            }
            return default(T)!;
        }

        private void SaveData<T>(string fileName, T data)
        {
            var filePath = Path.Combine(datax, fileName);
            try
            {
                var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en {filePath}: {ex.Message}");
            }
        }

        public List<Caso> GetCasos()
        {
            var casos = LoadData<List<Caso>>("caso.json") ?? new List<Caso>();
            return casos;
        }

        public Caso GetCasoById(int casoId)
        {
            var casos = GetCasos();
            return casos.FirstOrDefault(c => c.Id == casoId)!;
        }

        public void AddCaso(Caso caso)
        {
            var casos = GetCasos();
            caso.Id = casos.Any() ? casos.Max(c => c.Id) + 1 : 1;
            casos.Add(caso);
            SaveData("casos.json", casos);
        }

        public void UpdateCaso(Caso caso)
        {
            var casos = GetCasos();
            var existingCaso = casos.FirstOrDefault(c => c.Id == caso.Id);
            if (existingCaso != null)
            {
                existingCaso.Fecha = caso.Fecha;
                existingCaso.ClienteId = caso.ClienteId;
                existingCaso.AbogadoAsignado = caso.AbogadoAsignado;
                existingCaso.TipoCaso = caso.TipoCaso;
                existingCaso.Latitud = caso.Latitud;
                existingCaso.Longitud = caso.Longitud;
                existingCaso.Descripcion = caso.Descripcion;
                existingCaso.EstadoCaso = caso.EstadoCaso;
                SaveData("casos.json", casos);
            }
        }

        public void DeleteCaso(int casoId)
        {
            var casos = GetCasos();
            var casoToDelete = casos.FirstOrDefault(c => c.Id == casoId);
            if (casoToDelete != null)
            {
                casos.Remove(casoToDelete);
                SaveData("caso.json", casos);
            }
        }

    }
}
