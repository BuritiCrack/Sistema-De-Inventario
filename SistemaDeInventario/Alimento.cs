using System;
using System.Runtime.InteropServices;

namespace SistemaDeInventario
{
    public class Alimento : Producto
    {
        public DateTime FechaDeVencimiento { get; set; }

        public Alimento()
        {
            FechaDeVencimiento = DateTime.MinValue;
        }
        public Alimento(string nombre, TipoCategoria categoria, decimal precio, int cantidad, DateTime fechaIngreso, DateTime fechaDeVencimiento) : base( nombre, categoria, precio, cantidad, fechaIngreso)
        {
            FechaDeVencimiento = fechaDeVencimiento;
        }

        public void VencimientoAlimento() 
        {
            System.Console.WriteLine("Ingrese la fecha de vencimiento del alimento con el siguiente formato (dd/mm/yyyy):");
            string input = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                FechaDeVencimiento = DateTime.Parse(input);
            }
            else
            {
                throw new ArgumentNullException("La fecha de vencimiento no puede ser nula o vacía.");
            }

        }
        public override string ToString()
        {
            return base.ToString() + $"\nFecha de Vencimiento: {FechaDeVencimiento.ToShortDateString()}";
        }
    }
}