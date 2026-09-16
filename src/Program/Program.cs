//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Globalization;
namespace Ucu.Poo.Exercise
{
    public class Valor
    {
        
        public bool estado { get; set; }

        // Constructor del diagrama
        public Valor(bool estado)
        {
            this.estado = estado;
        }

        
        public virtual bool evaluar()
        {
            return this.estado;
        }
    }

    public class Compuerta : Valor
    {
        
        public string tipo { get; set; }
        public Valor entrada1 { get; set; }
        public Valor entrada2 { get; set; }

        // Constructor para 2 entradas (ej. AND, OR)
        public Compuerta(string tipo, Valor e1, Valor e2) : base(false)
        {
            
            ArgumentNullException.ThrowIfNull(tipo);

            
            this.tipo = tipo.ToUpper(CultureInfo.InvariantCulture);
            this.entrada1 = e1;
            this.entrada2 = e2; 
        }
        public Compuerta(string tipo, Valor e1) : base(false)
        {
            
            ArgumentNullException.ThrowIfNull(tipo);

            
            this.tipo = tipo.ToUpper(CultureInfo.InvariantCulture);
            this.entrada1 = e1;
            this.entrada2 = null; 
        }

        
        public override bool evaluar()
        {
            if (tipo == "NOT")
            {
                return !entrada1.evaluar();
            }
            if (tipo == "AND")
            {
                if (entrada2 == null)
                    throw new InvalidOperationException("La compuerta AND requiere dos entradas.");

                return entrada1.evaluar() && entrada2.evaluar();
            }
            if (tipo == "OR")
            {
                if (entrada2 == null)
                    throw new InvalidOperationException("La compuerta OR requiere dos entradas.");

                return entrada1.evaluar() || entrada2.evaluar();
            }

            throw new InvalidOperationException($"Tipo de compuerta desconocido: {tipo}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Valor v1 = new Valor(true);
            Valor v2 = new Valor(false);

            
            Compuerta compuertaNot = new Compuerta("not", v1); 
            Compuerta compuertaAnd = new Compuerta("and", v1, v2); 

            
            Compuerta circuitoFinal = new Compuerta("or", compuertaNot, compuertaAnd);

            
            bool resultado = circuitoFinal.evaluar();

            // Mostrar resultados en consola
            Console.WriteLine($"Estructura del circuito evaluado: NOT({v1.estado}) OR ({v1.estado} AND {v2.estado})");
            Console.WriteLine($"Tipo de compuerta raíz: {circuitoFinal.tipo}");
            Console.WriteLine($"Resultado final de la evaluación: {resultado}");
        }
    }
}





