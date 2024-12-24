using System.Net;
using System.Reflection;
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

        public void EliminarProducto(int eliminado)
        {
            _Productos.RemoveAt(eliminado);

        }

        public void VerProductos()
        {
            if (NoHayTareas())
            {
                return;
            }

            List<Producto> productos = new List<Producto>(_Productos);
            System.Console.WriteLine(CadenDeProductos(productos));
        }

        public bool NoHayTareas()
        {
            if(_Productos.Count == 0)
            {
                System.Console.WriteLine("No hay tareas");
                return true;
            }
            else
            {
                return false;
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

        public string CadenDeProductos(List<Producto> productos)
        {
            StringBuilder sb = new();
            int i = 0;
            foreach (Producto producto in productos)
            {
                if (_Productos[0] == null) {continue;}
                i++;
                String dato = String.Format("{0}. {1}\n", i, producto);
                sb.AppendLine(dato);
                
            }
            return sb.ToString();
        }    

    }
}