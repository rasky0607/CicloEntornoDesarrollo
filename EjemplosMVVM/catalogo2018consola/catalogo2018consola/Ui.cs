﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//añadido
using CatalogoDVD_wpf;
using System.Threading;


namespace catalogo2018consola
{
    class Ui
    {
        static DaoMysql dao;
        static string host="localhost";
        static string bd = "catalogo";
        static string usr ="root";
        static string pwd = "123";
        static string port = "3306";

        #region Constructor
        public Ui() 
        {
            dao = new DaoMysql();
            PedirOpcion();
        }  
        #endregion
        static void Menu()
        {
            Console.WriteLine("CATALOGO de DVDs - Opciones");
            Console.WriteLine("====================================");
            Console.WriteLine("[0]. Conectar.");
            Console.WriteLine("[1]. Desconectar.");
            Console.WriteLine("[2]. ¿Hay Conexión?.");
            Console.WriteLine("[3]. Seleccionar toda la tabla.");
            Console.WriteLine("[4]. Seleccionar un codigo de DVD.");
            Console.WriteLine("[5]. Seleccionar toda la tabla con PA \"procedimiento almacenados\".");
            Console.WriteLine("[6] Borrar un dvd de la tabla");
            Console.WriteLine("[7] Insertar un dvd en la tabla");
            Console.WriteLine("[S]. Salir.");
            Console.Write("Opcion: ");
        }

        static void PedirOpcion()
        {
            bool sipuede = false;
            do
            {
                Thread.Sleep(1000);
                Console.Clear();
            #region Pedirdatos Menu
            Menu();
            ConsoleKeyInfo opcion;
            opcion = Console.ReadKey();
            try
            {
                switch (opcion.KeyChar)
                { 
                    case'0':
                        if (!dao.Conectado())
                        { 
                            if(dao.Conectar(host,port,bd,usr,pwd))
                                Console.WriteLine("\nConecxion realizada con EXITO!");
                            else
                                Console.WriteLine("\nConexion FALLIDA!");
                        }
                        else
                             Console.WriteLine("\nYa hay una conexion establecida!.");
                        break;

                    case '1':
                        if (dao.Conectado())
                        {
                            dao.Desconectar();
                            Console.WriteLine("Te has desconectado de la BD: {0} con EXITO!", bd);
                        }
                        else
                            Console.WriteLine("No hay conecxion activa a la BD");
                
                        break;
                    case '2':// Comprobar si hay conecxion

                        if (dao.Conectado())
                            Console.WriteLine("Conecxion valida.");
                        else
                            Console.WriteLine("No hay conecxion...");
                        break;
                    case '3'://Selecionar generico toda la tabla
                        List<Dvd> listado = new List<Dvd>();
                        listado = dao.Seleccionar(null);
                        MostrarListado(listado);
                        Console.ReadLine();//Provisional, para que no limpie la pantalla
                        break;
                    case '4'://seleciona un codigo de DVD
                          List<Dvd> listado2 = new List<Dvd>();
                        listado2 = dao.Seleccionar("1000");
                        Console.WriteLine();
                        MostrarListado(listado2);
                        Console.ReadLine();//Provisional, para que no limpie la pantalla
                        break;
                    case '5'://selecionar toda la tabla a traves de un procedimiento almacenado
                        List<Dvd> listado3 = new List<Dvd>();
                        int resultado ;
                        listado3 = dao.SeleccionarPA(null,out resultado);//out resultado es el parametro de salida obtenido nos informa de si todo fue bien o no, ( o 1 o 0)
                        Console.WriteLine("Resultado filas retornadas: {0}", resultado);
                        if (resultado != 0)//osea si todo ha ido bien
                            MostrarListado(listado3);
                        else
                            Console.WriteLine("No hay resultado...");
                        Console.ReadLine();//Provisional, para que no limpie la pantalla
                        break;
                    case '6': //borrar un dvd de la tabla
                        Console.WriteLine("¿Codigo del DVD a eliminar?");
                        string codigo = Console.ReadLine();
                        Console.WriteLine(dao.Borrar(codigo) + " fila/s borrada/s");
                        break;

                    case '7': //Inserta un dvd en la tabla
                        Console.WriteLine("¿Codigo del DVD a insertar?");
                        Dvd elDVD = new Dvd();
                        elDVD.Codigo = short.Parse(Console.ReadLine());
                        elDVD.Titulo = "Titulo1";
                        elDVD.Compania = "compañia1";
                        elDVD.Anio = "2010";
                        elDVD.Precio = 10.00;
                        elDVD.Pais = "US";
                        elDVD.Artista = "artista1";
                        Console.WriteLine(dao.Insertar(elDVD) + " fila/s insertada/s");
                        break;
                        //Salir
                    case 's':
                        sipuede = true;                      
                        Console.Clear();
                        Console.WriteLine("\n\t\t\t\t<=======Bye!========>");
                        Thread.Sleep(800);
                        break;
                    case 'S':
                         sipuede = true;                       
                        Console.Clear();
                        Console.WriteLine("\n\t\t\t\t<=======Bye!========>");
                        Thread.Sleep(800);
                        break;
                        //---------//
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            #endregion
            }while(!sipuede);

        }

        private static void MostrarListado(List<Dvd> listado)
        {
            if (dao.Conectado())
            {
                foreach (Dvd item in listado)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
                Console.WriteLine("ERROR: no hay conecxion");
        }
    }
}
