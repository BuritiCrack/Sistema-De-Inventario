using System;

namespace SistemaDeInventario
{
    public class Electrodomestico : Producto
    {
        public int Voltaje { get; set; }

        public Electrodomestico()
        {
            Voltaje = 0;
        }
        public Electrodomestico(string nombre, TipoCategoria categoria, decimal precio, int cantidad, DateTime fechaIngreso, int voltaje)
                                 : base(nombre, categoria, precio, cantidad, fechaIngreso)
        {
            Voltaje = voltaje;
        }

        public void VoltajeElec()
        {
            Console.Write("Ingrese el voltaje del electrodoméstico: ");
            Voltaje = int.Parse(Console.ReadLine()!);
        }
        public override string ToString()
        {
            return string.Format("ID: {0}\nCategoría: {1}\nNombre: {2}\nVoltaje: {3}\nPrecio: {4:C}\nCantidad: {5}\nFecha de ingreso: {6}",
                                  ID, Categoria, Nombre, Voltaje, Precio, Cantidad, FechaIngreso.ToShortDateString());
        }
    }
}