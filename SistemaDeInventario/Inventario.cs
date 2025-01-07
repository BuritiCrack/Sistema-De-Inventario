using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SistemaDeInventario
{
    public class Inventario
    {
        private List<Producto> _productos;

        public Inventario()
        {
            _productos = Persistencia.CargarDatos();
        }

        public void AgregarProducto(Producto producto)
        {
            _productos.Add(producto);
            GuardarDatos();
        }

        public void EliminarProducto(int eliminado)
        {
            _productos.RemoveAt(eliminado);
            GuardarDatos();
        }

        public void VerProductos()
        {
            if (NoHayProductos())
            {
                return;
            }

            List<Producto> productos = new List<Producto>(_productos);
            System.Console.WriteLine(CadenDeProductos(productos));
        }

        public void OrdenarPorNombre()
        {
            List<Producto> productos = new List<Producto>(_productos);
            productos.Sort((x, y) => x.Nombre.CompareTo(y.Nombre));
            System.Console.WriteLine(CadenDeProductos(productos));
        }

        public void OrdenarPorNombreDesc()
        {
            List<Producto> productos = new List<Producto>(_productos);
            productos.Sort((x, y) => y.Nombre.CompareTo(x.Nombre));
            System.Console.WriteLine(CadenDeProductos(productos));
        }

        public void OrdenarPorPrecio()
        {
            List<Producto> productos = new List<Producto>(_productos);
            productos.Sort((x, y) => x.Precio.CompareTo(y.Precio)); 
            System.Console.WriteLine(CadenDeProductos(productos)); 
        }

        public void OrdenarPorPrecioDesc()
        {
            List<Producto> productos = new List<Producto>(_productos);
            productos.Sort((x, y) => y.Precio.CompareTo(x.Precio));
            System.Console.WriteLine(CadenDeProductos(productos));
        }

        public bool NoHayProductos()
        {
            if (_productos.Count == 0)
            {
                System.Console.WriteLine("No hay productos en el inventario.");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EditarProducto(int posicionProducto, string nombre, Producto.TipoCategoria categoria, int cantidad, decimal precio)
        {
            _productos[posicionProducto].Nombre = nombre;
            _productos[posicionProducto].Categoria = categoria;
            _productos[posicionProducto].Cantidad = cantidad;
            _productos[posicionProducto].Precio = precio;

            if (_productos[posicionProducto] is Alimento)
            {
                Alimento alimento = (Alimento)_productos[posicionProducto];
                alimento.VencimientoAlimento();
            }
            else if (_productos[posicionProducto] is Electrodomestico)
            {
                Electrodomestico electrodomestico = (Electrodomestico)_productos[posicionProducto];
                electrodomestico.VoltajeElec();
            }
            else if (_productos[posicionProducto] is Moda)
            {
                Moda moda = (Moda)_productos[posicionProducto];
                moda.TallaColor();
            }
            GuardarDatos();
        }

        public Producto? BuscarProductoPorNombre(string nombre)
        {
            foreach (Producto producto in _productos)
            {
                if (producto != null && producto.Nombre == nombre)
                {
                    return producto;
                }
            }
            return null;
        }


        public string CadenDeProductos(List<Producto> productos)
        {
            StringBuilder sb = new();
            int i = 0;
            foreach (Producto producto in productos)
            {
                if (_productos[0] == null) { continue; }
                i++;
                String dato = String.Format("{0}. {1}\n", i, producto);
                sb.AppendLine(dato);

            }
            return sb.ToString();
        }

        private void GuardarDatos()
        {
            Persistencia.GuardarDatos(_productos);
        }
    }
}