using System.ComponentModel.Design;
using System.Text;

namespace SistemaDeInventario;

class Program
{
    static GestorDeInventario gestorDeInventario = new(new Inventario()); 
    //static string archivo = "productos.json";

    static void Main(string[] args)
    {
        //Persistencia.CargarDatos();
        while (true)
        {
            LimpiarPantalla();
            Menu();
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    gestorDeInventario.AgregarProducto();
                    break;
                case 2:
                    gestorDeInventario.EliminarProducto();
                    break;
                case 3:
                    gestorDeInventario.VerProductos();
                    break;
                case 4:
                    gestorDeInventario.ActualizarProducto();
                    break;
                case 5:
                    gestorDeInventario.BuscarProductoPorNombre();
                    break;
                case 6:
                    gestorDeInventario.VerOrdenados();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        
        
    }

    public static void Menu()
    {
        StringBuilder sb = new();
        sb.AppendLine("Menú de opciones:");
        sb.AppendLine("1. Agregar producto");
        sb.AppendLine("2. Eliminar producto");
        sb.AppendLine("3. Ver productos");
        sb.AppendLine("4. Actualizar productos");
        sb.AppendLine("5. Buscar por nombre");
        sb.AppendLine("6. Ver productos Ordenados");
        sb.AppendLine("7. Salir");
        sb.Append("Ingrese el número de la opción deseada: ");
        Console.Write(sb.ToString());
    }

    static public void LimpiarPantalla()
        {
            Console.Clear();
        }

        static public void PresionarTecla()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
}
