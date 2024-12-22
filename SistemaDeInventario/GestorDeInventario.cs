using System.Text;

namespace SistemaDeInventario
{
    public class GestorDeInventario
    {
        private Inventario _inventario;

        public GestorDeInventario(Inventario inventario)
        {
            _inventario = inventario;
        }

        public void AgregarProducto()
        {
            Producto producto = new();

            LimpiarPantalla();
            ListadoCategoria();
            int opcion;

            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
            switch (opcion)
            {
                case 1:
                    Alimento alimento = new();
                    alimento.VencimientoAlimento();
                    producto = alimento;
                    producto.Categoria = Producto.TipoCategoria.Alimento;
                    break;
                case 2:
                    producto.Categoria = Producto.TipoCategoria.Oficina;
                    break;
                case 3:
                    Moda moda = new();
                    moda.TallaColor();
                    producto = moda;
                    producto.Categoria = Producto.TipoCategoria.Moda;
                    break;
                case 4:
                    Electrodomestico electrodomestico = new();
                    electrodomestico.VoltajeElec();
                    producto = electrodomestico;
                    producto.Categoria = Producto.TipoCategoria.Electrodomestico;
                    break;
                case 5:
                    producto.Categoria = Producto.TipoCategoria.Deporte;
                    break;
                case 6:
                    producto.Categoria = Producto.TipoCategoria.Hogar;
                    break;
                case 7:
                    producto.Categoria = Producto.TipoCategoria.Otro;
                    break;

            }

            Console.Write("Ingrese el nombre del producto: ");
            producto.Nombre = Console.ReadLine()!;
            Console.Write("Ingrese la cantidad: ");
            producto.Cantidad = int.Parse(Console.ReadLine()!);
            Console.Write("Ingrese el precio unitario: ");
            producto.Precio = decimal.Parse(Console.ReadLine()!);
            producto.FechaIngreso = DateTime.UtcNow;

            _inventario.AgregarProducto(producto);
            Console.WriteLine("Producto agregado exitosamente.");
            PresionarTecla();

        }

        public void ListadoCategoria()
        {
            StringBuilder sb = new();
            sb.AppendLine("1. Alimento");
            sb.AppendLine("2. Oficina");
            sb.AppendLine("3. Moda");
            sb.AppendLine("4. Electrodoméstico");
            sb.AppendLine("5. Deporte");
            sb.AppendLine("6. Hogar");
            sb.AppendLine("7. Otro");
            sb.Append("Seleccione la categoría del producto: ");
            Console.Write(sb.ToString());
        }
        public void VerProductos()
        {    
            LimpiarPantalla();
            _inventario.MostrarProductos();
            PresionarTecla();
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
}