using System;

namespace SistemaDeInventario
{
    public class Producto : IComparable<Producto>
    {
        //full property
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public TipoCategoria Categoria { get; set; }
        //Backing field
        private decimal _precio;
        public decimal Precio 
        { 
            get {return _precio; }
            set 
            {
                /*Evitar valores negativos
                if (value < 0)
                {
                    throw new ArgumentException("El precio no puede ser negativo");
                }
                _precio = value;
                */
                _precio = value < 0 ? throw new ArgumentException("El precio no puede ser negativo") : value;

            }
        }
        private int _cantidad;
        public int Cantidad 
        { 
            get { return _cantidad; }
            set 
            {
                while (value < 0)
                {
                    Console.WriteLine("La cantidad no puede ser negativa. Por favor, ingrese un valor positivo:");
                    if (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                        value = -1; // Forzar la repetición del bucle
                    }
                }
                _cantidad = value;
            } 
        }
        public DateTime FechaIngreso { get; set; }

        public enum TipoCategoria
        {
            Alimento,
            Oficina,
            Moda,
            Electrodomestico,
            Deporte,
            Hogar,
            Otro
        }

        public Producto() 
        {
            ID = Guid.NewGuid();
            Nombre = string.Empty; // Initialize Nombre to an empty string
            FechaIngreso = DateTime.UtcNow.ToLocalTime();
        }
        public Producto(string nombre, TipoCategoria categoria, decimal precio, int cantidad, DateTime fechaIngreso)
        {
            ID = Guid.NewGuid();
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Cantidad = cantidad;
            FechaIngreso = fechaIngreso;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null)
            {
                return false;
            }

            if (obj is not Producto p)
            {
                return false;
            }

            return (ID == p.ID) && (Nombre == p.Nombre) && (Categoria == p.Categoria) && (Precio == p.Precio);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + ID.GetHashCode();
            hash = (hash * 7) + Nombre.GetHashCode();
            hash = (hash * 7) + Categoria.GetHashCode();
            hash = (hash * 7) + Precio.GetHashCode();

            return hash;
        }

        public int CompareTo(Producto? other)
        {
            if (other == null)
            {
                return 1;
            }

            return ID.CompareTo(other.ID);
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nCategoría: {1}\nNombre: {2}\nPrecio: {3:C}\nCantidad: {4}\nFecha de ingreso: {5}", 
                                  ID, Categoria, Nombre, Precio, Cantidad, FechaIngreso.ToShortDateString());
        }
    }
}