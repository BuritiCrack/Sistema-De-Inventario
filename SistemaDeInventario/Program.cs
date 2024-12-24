using System.ComponentModel.Design;
using System.Text;

namespace SistemaDeInventario;

class Program
{
    static void Main(string[] args)
    {
        GestorDeInventario gestorDeInventario = new(new Inventario());

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
                    return;
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
        sb.AppendLine("4. Salir");
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
