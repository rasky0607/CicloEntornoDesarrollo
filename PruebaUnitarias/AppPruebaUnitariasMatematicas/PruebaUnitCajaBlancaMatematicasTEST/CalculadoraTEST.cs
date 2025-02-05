﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//Añadido el espacio de nombre del proyecto que vamos a probar,para poder ver sus metodos"ademas de  colocar dichos metodos como publicos
using AppPruebaUnitariasMatematicas.pbl;

namespace PruebaUnitCajaBlancaMatematicasTEST
{
    /*
     Primer paso antes de empezar , agregar a las referencias  de el proyecto de PruebaUnitCajaBlancaMatematicasTEST el proyecto a probar
     (Boton derecho en referencias de "PruebaUnitCajaBlancaMatematicasTEST") y agregar referencia "en la pestaña de solucion" ,y marcamos el proyecto que probaremos con este.
     * 
     Segundo paso: Pestaña de PRUEBA  y en ejecutar todas las pruebas.
     */
    [TestClass]
    public class CalculadoraTEST
    {
        //Camino1
        [TestMethod]//Para cara metodo a probar
        [ExpectedException(typeof(FaltaParametroException))] //Cuando el metodo espera recibir una excepcion tras probarlo y que excepcion recibe.
        public void C1esPrimo_NULL_ExcepcionE1()
        {
          string[] valores = { };//Valor de entrada que vamos a dar para probar el primer camino.
          Calculadora.EsPrimo(valores);//LLamamos al metodo a probar  
           
        }

        //Camino2
        [TestMethod]//Para cara metodo a probar
        [ExpectedException(typeof(DemasiadosParametrosException))] //Cuando el metodo espera recibir una excepcion tras probarlo y que excepcion recibe.
        public void C2esPrimo_ArrayDosParametros_ExceptionE2()
        {
            string[] valores = {"5", "8"};//Valor de entrada que vamos a dar para probar el primer camino.
            Calculadora.EsPrimo(valores);//LLamamos al metodo a probar  
        }

        //Camino3
        [TestMethod]//Para cara metodo a probar
        [ExpectedException(typeof(NoNumberException))] //Cuando el metodo espera recibir una excepcion tras probarlo y que excepcion recibe.
        public void C3esPrimo_ArraySinNumero_ExceptionE3()
        {
            string[] valores = {"a"};//Valor de entrada que vamos a dar para probar el primer camino.
            Calculadora.EsPrimo(valores);//LLamamos al metodo a probar  
        }

        //Camino4
        [TestMethod]//Para cara metodo a probar
        [ExpectedException(typeof(NumenoNoPositivoException))] //Cuando el metodo espera recibir una excepcion tras probarlo y que excepcion recibe.
        public void C4esPrimo_ArrayValorNegativo_ExceptionE4()
        {
            string[] valores = {"-1"};//Valor de entrada que vamos a dar para probar el primer camino.
            Calculadora.EsPrimo(valores);//LLamamos al metodo a probar  
        }

        //Camino5
        [TestMethod]//Para cara metodo a probar
        public void C5esPrimo_DOS_TRUE()
        {
            string[] valores = { "2" };//Valor de entrada que vamos a dar para probar el primer camino.
            //Assert -> para recoger un dato  que vamos a probar que  no va devolver una excepcion  y si cumple el metodo, en este caso termian el metodo y devuelve un true
            Assert.IsTrue(Calculadora.EsPrimo(valores));//LLamamos al metodo a probar  
        }
        //Camino6
        [TestMethod]//Para cara metodo a probar
        public void C6esPrimo_CUATRO_FALSE()
        {
            string[] valores = { "4" };//Valor de entrada que vamos a dar para probar el primer camino.
            //Assert -> para recoger un dato  que vamos a probar que  no va devolver una excepcion y si cumple el metodo, en este caso termian el metodo y devuelve un falso
            Assert.IsFalse(Calculadora.EsPrimo(valores));//LLamamos al metodo a probar  
        }

        //Camino7
        [TestMethod]//Para cara metodo a probar
        public void C7esPrimo_TRES_TRUE()
        {
            string[] valores = { "3" };//Valor de entrada que vamos a dar para probar el primer camino.
            //Assert -> para recoger un dato  que vamos a probar que  no va devolver una excepcion y si cumple el metodo, en este caso termian el metodo y devuelve un falso
            Assert.IsTrue(Calculadora.EsPrimo(valores));//LLamamos al metodo a probar  
        }

        //Camino8
        [TestMethod]
        [ExpectedException(typeof(NumeracoException))]//Excepcion esperada.
        public void EsPrimo_ValorOVerflow()
        {
            Int64 valor = Int32.MaxValue;
            //uno mas para qeu se desborde con un int de 32 bits
            valor++;
            string[] valores ={valor.ToString()};
            Calculadora.EsPrimo(valores);
        }

        //Pruebas Unitarias del método de calculo de DC

        [TestMethod]
        public void C1_CalcularDC_12335678000012335678_11()
        { 
            string valor = "12335678000012335678";
            string resultado = Calculadora.CalcularDC(valor);
            Assert.AreEqual("11", resultado);//AreEqual (Que espero obtener "11" dado una cadena un resultado osea compara lo que devuelve el metodo con lo esperado , si son iguales pasa ,si no no pasa)
        }

         [TestMethod]//No superada
        public void C2_CalcularDC_12345678001234567890_06()
        {
            string valor = "12335678000012335678";
            string resultado = Calculadora.CalcularDC(valor);
            Assert.AreEqual("06", resultado);//AreEqual (Que espero obtener "11" dado una cadena un resultado osea compara lo que devuelve el metodo con lo esperado , si son iguales pasa ,si no no pasa)
        }
        
    }
}
