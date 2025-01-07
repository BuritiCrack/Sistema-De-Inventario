using System.Text.Json;
namespace SistemaDeInventario
{
    public static class Persistencia
    {
        private static string _filePath = AppDomain.CurrentDomain.BaseDirectory + @"\productos.json";

        public static void GuardarDatos(List<Producto> productos)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(productos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonString);
                Console.WriteLine("Datos guardados exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los datos: {ex.Message}");
            }
        }

        public static List<Producto> CargarDatos()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonString = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<Producto>>(jsonString) ?? new List<Producto>();
                }
                else
                {
                    Console.WriteLine("El archivo no existe. Se creará uno nuevo al guardar los datos.");
                    return new List<Producto>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los datos: {ex.Message}");
                return new List<Producto>();
            }
        }
    }
}