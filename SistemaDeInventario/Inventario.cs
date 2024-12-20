using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SistemaDeInventario
{
    public class Inventario
    {
        private List<Producto> _Productos;

        public Inventario()
        {
            _Productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            _Productos.Add(producto);
        }

        public void EliminarProducto(Guid id)
        {
            Producto? producto = _Productos.Find(p => p.ID == id);
            if (producto != null)
            {
                _Productos.Remove(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

        }

        public void ActualizarProducto(Guid id, Producto producto)
        {
            Producto? productoActualizado = _Productos.Find(p => p.ID == id);
            if (productoActualizado != null)
            {
                productoActualizado.Nombre = producto.Nombre;
                productoActualizado.Categoria = producto.Categoria;
                productoActualizado.Precio = producto.Precio;
                productoActualizado.Cantidad = producto.Cantidad;
                productoActualizado.FechaIngreso = producto.FechaIngreso;
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        private bool NoHayProductos()
        {
            if (_Productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                return true;
            }
            return false;
        }
        public void MostrarProductos()
        {
            if (NoHayProductos())
            {
                return;
            }

            List<Producto> productos = new List<Producto>(_Productos);
            Console.WriteLine(CadenaDeProductos(productos));
        }
       
        public Producto? BuscarPorNombre(string nombre)
        {
            if (NoHayProductos())
            {
                return null;
            }

            Producto? p = _Productos.Find(p => p.Nombre == nombre);
            if (p == null)
            {
                Console.WriteLine("Producto no encontrado.");
            }
            return p;
        }

        private string CadenaDeProductos(List<Producto> productos)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (Producto producto in productos)
            {
                if (_Productos == null) {continue;}
                i++;
                string dato = string.Format("{0}. {1}\n", i, producto); 
                sb.AppendLine(dato);
            }

            return sb.ToString();
        }

    }
}