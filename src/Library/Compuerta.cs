using System;
using System.Globalization;

namespace Ucu.Poo.Exercise
{
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

        // Constructor para 1 entrada (ej. NOT)
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
}