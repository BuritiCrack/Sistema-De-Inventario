using System.Diagnostics;
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
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una categoría válida.");
                    PresionarTecla();
                    return;
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
            _inventario.VerProductos();
            PresionarTecla();
        }

        public void EliminarProducto()
        {
            LimpiarPantalla();
            if (NoHayProductos())
            {
                return;
            }
            VerProductos();
            System.Console.Write("Ingrese la posicion del producto que desea eliminar: ");
            int eliminado = int.Parse(Console.ReadLine()!);
            _inventario.EliminarProducto(eliminado - 1);

            System.Console.WriteLine("Producto eliminado exitosamente.");
            PresionarTecla();

        }

        public void ActualizarProducto()
        {
            LimpiarPantalla();
            if (NoHayProductos())
            {
                return;
            }
            VerProductos();
            System.Console.Write("Ingrese la posición del producto que desea editar: ");
            int posicionProducto = int.Parse(Console.ReadLine()!);
            posicionProducto -= 1;

            LimpiarPantalla();
            ListadoCategoria();
            int opcion = int.Parse(Console.ReadLine()!);
            switch (opcion)
            {
                case 1: // Alimento
                    ActualizarItems(out string nombre, out int cantidad, out decimal precio);
                    _inventario.EditarProducto(posicionProducto, nombre, Producto.TipoCategoria.Alimento, cantidad, precio);
                    System.Console.WriteLine("Producto actualizado exitosamente.");
                    break;
                case 2: // Oficina
                    ActualizarItems(out nombre, out cantidad, out precio);
                    _inventario.EditarProducto(posicionProducto, nombre, Producto.TipoCategoria.Oficina, cantidad, precio);
                    System.Console.WriteLine("Producto actualizado exitosamente.");
                    break;
                case 3: // Moda
                    ActualizarItems(out nombre, out cantidad, out precio);
                    _inventario.EditarProducto(posicionProducto, nombre, Producto.TipoCategoria.Moda, cantidad, precio);
                    System.Console.WriteLine("Producto actualizado exitosamente.");
                    break;
                case 4: // Electrodoméstico
                    ActualizarItems(out nombre, out cantidad, out precio);
                    _inventario.EditarProducto(posicionProducto, nombre, Producto.TipoCategoria.Electrodomestico, cantidad, precio);
                    System.Console.WriteLine("Producto actualizado exitosamente.");
                    break;
                case 5: // Deporte
                    ActualizarItems(out nombre, out cantidad, out precio);
                    _inventario.EditarProducto(posicionProducto, nombre, Producto.TipoCategoria.Deporte, cantidad, precio);
                    System.Console.WriteLine("Producto actualizado exitosamente.");
                    break;
                case 6: // Hogar
                    ActualizarItems(out nombre, out cantidad, out precio);
                    _inventario.EditarProducto(posicionProducto, nombre, Producto.TipoCategoria.Hogar, cantidad, precio);
                    System.Console.WriteLine("Producto actualizado exitosamente.");
                    break;
                case 7: // Otro
                    ActualizarItems(out nombre, out cantidad, out precio);
                    _inventario.EditarProducto(posicionProducto, nombre, Producto.TipoCategoria.Otro, cantidad, precio);
                    System.Console.WriteLine("Producto actualizado exitosamente.");
                    break;
                default:
                    System.Console.WriteLine("Opción no válida. Por favor, seleccione una categoría válida.");
                    PresionarTecla();
                    return;
            }

        }

        public void ActualizarItems(out string nombre,out int cantidad,out decimal precio)
        {
            LimpiarPantalla();
            Console.Write("Ingrese el nuevo nombre del producto: ");
            nombre = Console.ReadLine()!;
            Console.Write("Ingrese la nueva cantidad: ");
            cantidad = int.Parse(Console.ReadLine()!);
            Console.Write("Ingrese el nuevo precio unitario: ");
            precio = decimal.Parse(Console.ReadLine()!);
        }

        public void Buscar()
        {
            LimpiarPantalla();
            if (NoHayProductos())
            {
                return;
            }
            ListaBuscar();
            int opcion = int.Parse(Console.ReadLine()!);
            switch (opcion)
            {
                case 1:
                    BuscarProductoPorNombre();
                    break;
                case 2:
                   // BuscarProductoPorCategoria();
                    break;
                case 3:
                  //  BuscarProductoPorPrecio();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una categoría válida.");
                    PresionarTecla();
                    return;
            }
            PresionarTecla();

        }

        public void ListaBuscar()
        {
            StringBuilder sb = new();
            sb.AppendLine("1. Buscar por nombre");
            sb.AppendLine("2. Buscar por categoría");
            sb.AppendLine("3. Buscar por precio");
            sb.Append("Seleccione el criterio de búsqueda: ");
            Console.Write(sb.ToString());
        }
        public void BuscarProductoPorNombre()
        {
            LimpiarPantalla();
            Console.Write("Ingrese el nombre del producto que desea buscar: ");
            string nombre = Console.ReadLine()!;
            Producto? producto = _inventario.BuscarProductoPorNombre(nombre);
            if (producto != null)
            {
                Console.WriteLine("Producto: \n" + producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            PresionarTecla();
        }

        public bool NoHayProductos()
        {
            if (_inventario.NoHayProductos())
            {
                PresionarTecla();
                return true;
            }
            else
            {
                return false;
            }
        }

        static public void LimpiarPantalla()
        {
                 Console.Clear();
        }
        public void PresionarTecla()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

    }
}