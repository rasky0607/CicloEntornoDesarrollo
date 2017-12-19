/*
 Autor: Pablo Lopez
 Ejemplo consola ENDE"Entorno desarrollo": Uso de la calse Stopwatch para calcular los ticks de cpu que usa nuestro codigo
 Fecha:19/12/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Añadido
using System.Diagnostics;

namespace AppRendimienClaseStopwatch.pbl
{
    class Program
    {
        static double FactorialRecursivo(uint numero)
        {
            //Caso Base (Factorial de 0 = 1)
            if (numero == 0)
                return 1;
            else
                return numero * FactorialRecursivo(numero - 1);
        }

        static double FactorialIterativo(uint numero)
        {
            long result = 1;
            if (numero == 0)
                return 1;

            for (int i = 1; i <= numero; i++)
            {
                result *= i;
            }
            return result;
        }
        static void ArrayConBucleFor(int[] entrada)
        {
            for (int i = 0; i < entrada.Length; i++)
            {
                entrada[i] += 1;
            }
        }


        static void ArrayConBucleForEach(int[] entrada)
        {
            int i = 0;
            foreach (int item in entrada)
                entrada[i++]++;

        }

        static void InicializaArray(out int[] entrada, uint nValores)
        {
            entrada = new int[nValores];
            Random rnd = new Random();
            for (int i = 0; i < nValores; i++)
            {
                entrada[i] = rnd.Next(1, 101);
            }
        }

        static void Main(string[] args)
        {
            Stopwatch crono = new Stopwatch();

            uint factorialCandidato = 170;

            Console.WriteLine("\n -Metodo Recursivo:");
            crono.Start();
            Console.WriteLine(" El Factorial Recursivo de {0} es-> {1:E1} ", factorialCandidato, FactorialRecursivo(factorialCandidato));
            crono.Stop();
            Console.WriteLine(" Tiempo y ticks transcurrido: {0} / {1} ", crono.Elapsed, crono.ElapsedTicks);

            Console.WriteLine("\n -Metodo Iterativo:");

            Stopwatch crono2 = new Stopwatch();
            crono2.Start();
            Console.WriteLine(" El Factorial Iteractivo de {0} es-> {1:E1} ", factorialCandidato, FactorialIterativo(factorialCandidato));
            crono2.Stop();
            Console.WriteLine(" Tiempo y ticks transcurrido: {0} / {1} ", crono2.Elapsed, crono2.ElapsedTicks);

            Console.WriteLine("\n -Pruebas de tiempo recorriendo colecciones:");
            int[] coleccion = { 1, 4, 6, 2, 7, 9, 3, 4, 5, 3, 4, 5 };

            crono2.Restart();
            ArrayConBucleForEach(coleccion);
            crono2.Stop();
            Console.WriteLine(" Tiempo y ticks transcurrido: {0} / {1} ", crono2.Elapsed, crono2.ElapsedTicks);

            crono.Restart();
            ArrayConBucleFor(coleccion);
            crono.Stop();
            Console.WriteLine(" Tiempo y ticks transcurrido: {0} / {1} ", crono.Elapsed, crono.ElapsedTicks);

            Console.WriteLine("\n -Inicializa coleccion a valores aleatorios:");
            int[] coleccion2;
            crono2.Restart();
            InicializaArray(out coleccion2, 100);
            crono2.Stop();
            Console.WriteLine(" Tiempo y ticks transcurrido: {0} / {1} ", crono2.Elapsed, crono2.ElapsedTicks);

            Console.ReadLine();

        }
    }
}
