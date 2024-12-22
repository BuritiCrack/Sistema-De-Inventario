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
        public Electrodomestico(string nombre, TipoCategoria categoria, decimal precio, int cantidad, DateTime fechaIngreso, int voltaje) : base(nombre, categoria, precio, cantidad, fechaIngreso)
        {
            Voltaje = voltaje;
        }

        public void VoltajeElec()
        {
            Console.WriteLine("Ingrese el voltaje del electrodoméstico:");
            Voltaje = int.Parse(Console.ReadLine()!);
        }
        public override string ToString()
        {
            return base.ToString() + $" Voltaje: {Voltaje}V";
        }
    }
}