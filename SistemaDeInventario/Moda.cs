using System;

namespace SistemaDeInventario
{
    public class Moda : Producto
    {
        public string? Talla { get; set; }
        public string? Color { get; set; }

        public Moda()
        {
            Talla = string.Empty;
            Color = string.Empty;
        }
        public Moda(string nombre, string categoria, decimal precio, int cantidad, DateTime fechaIngreso, string talla, string color) : base(nombre, TipoCategoria.Otro , precio, cantidad, fechaIngreso)
        {
            Talla = talla;
            Color = color;
        }

        public void TallaColor()
        {
            Console.Write("Ingrese la talla de la prenda:");
            Talla = Console.ReadLine();
            Console.Write("Ingrese el color de la prenda:");
            Color = Console.ReadLine();
        }
        public override string ToString()
        {
            return string.Format("ID: {0}\nNombre: {1}\nCategoría: {2}\nTalla: {3}\nColor: {4}\nPrecio: {5:C}\nCantidad: {6}\nFecha de ingreso: {7}",
                                  ID, Categoria, Nombre, Talla, Color, Precio, Cantidad, FechaIngreso.ToShortDateString()); 
        }
    }
}