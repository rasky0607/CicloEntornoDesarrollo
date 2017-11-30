/*
 Autor: Pablo Lopez
 Ejemplo consola: de pruebas Unitarias tras calcular su complegidad ciclomatica
 Fecha:23/11/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppPruebaUnitariasMatematicas.pbl
{
    //Los metodos se colocaran publicos, para poder probarlos en el proyecto de pruebas "CalculadoraTEST"
    public class DemasiadosParametrosException : Exception { }
    public class FaltaParametroException : Exception { }
    public class NoNumberException : Exception { }
    public class NumenoNoPositivoException : Exception { }
    public class NumeroDemasiadoGrandeException : Exception { }
    public class NumeracoException : Exception { }

    public class Calculadora
    {

        static void Main(string[] args)
        {

        }

        public static bool EsPrimo(string[] args)
        {                                        //Señalando caminos basicos:
            if (args.Length == 0)                   //1                 
                throw new FaltaParametroException();//E1-> "Excepcion 1 "toda excepcion termina directamente la ejecucion(no es rescatable)     "Lanza una nueva excepcion declarada en esa clase."

            else if (args.Length > 1)               //2
                throw new DemasiadosParametrosException();//E2
            else//LOS ELSE NO SON CAMINOS BASICOS
            {
                try
                {
                    int numero = int.Parse(args[0]);//3
                    if (numero < 0)                 //4
                        throw new NumenoNoPositivoException();//E4
                    else
                    {
                        //Por fin podemos calcular en un entorno seguro
                        //5     6           9
                        for (int i = 2; i < numero; i++)
                        {
                            if (numero % i == 0)//7
                                return false;//8
                        }
                    }

                }
                catch (FormatException)
                {
                    throw new NoNumberException();  //E3
                }
                catch (OverflowException) 
                { 
                    throw new NumeracoException();//E8
                }
            }

            return true;//10
        }//11 Despues de cada excecion no ira al ture.. si no a  esata llave de finalizacion del metodo.

        public static bool EsPrimo2(string[] args)
        {                                        //Señalando caminos basicos:
            if (args.Length == 0)                   //1                 
                throw new FaltaParametroException();//E1-> "Excepcion 1 "toda excepcion termina directamente la ejecucion(no es rescatable)     "Lanza una nueva excepcion declarada en esa clase."

            else if (args.Length > 1)               //2
                throw new DemasiadosParametrosException();//E2
            else//LOS ELSE NO SON CAMINOS BASICOS
            {
              
                    //int numero = int.Parse(args[0]);//3
                    int numero;
                    if (!int.TryParse(args[0], out numero))//E3
                        throw new NoNumberException();

                    else if (numero < 0)  //4

                        throw new NumenoNoPositivoException();//E4
                    else
                    {
                        //Por fin podemos calcular en un entorno seguro
                        //5     6           9
                        for (int i = 2; i < numero; i++)
                        {
                            if (numero % i == 0)//7
                                return false;//8
                        }
                    }
                          
            }

            return true;//10
        }//11 Despues de cada excecion no ira al ture.. si n oa  esata llave de finalizacion del metodo.

    }
}
