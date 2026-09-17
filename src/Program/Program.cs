//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Exercise
{
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

            Console.WriteLine($"Estructura del circuito evaluado: NOT({v1.estado}) OR ({v1.estado} AND {v2.estado})");
            Console.WriteLine($"Tipo de compuerta raíz: {circuitoFinal.tipo}");
            Console.WriteLine($"Resultado final de la evaluación: {resultado}");
        }
    }
}