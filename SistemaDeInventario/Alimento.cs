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
        public Alimento(string nombre, TipoCategoria categoria, decimal precio, int cantidad, DateTime fechaIngreso, DateTime fechaDeVencimiento) 
                        : base( nombre, categoria, precio, cantidad, fechaIngreso)
        {
            FechaDeVencimiento = fechaDeVencimiento;
        }

        public void VencimientoAlimento() 
        {
            System.Console.Write("Ingrese la fecha de vencimiento del alimento con el siguiente formato (dd/mm/yyyy): ");
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
            return string.Format("ID: {0}\nCategoría: {1}\nNombre: {2}\nPrecio: {3:C}\nCantidad: {4}\nFecha de ingreso: {5}\nFecha de vencimiento: {6}",
                                  ID, Categoria, Nombre, Precio, Cantidad, FechaIngreso.ToShortDateString(), FechaDeVencimiento.ToShortDateString());
        }
    }
}