using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

/*Acronimo que debe cumplir el controlador de datos CRUD:
 * Create 
 * Read 
 * Update 
 * Delete*/
namespace CatalogoDVD_wpf
{
    interface IDAO
    {
        bool Conectar(string srv,string port, string db, string user, string pwd);
        void Desconectar();
        bool Conectado();
        //Read
        List<Dvd> SeleccionarPA(string codi,out short resul);//Seleccionar mediante un procedimiento almacenado
        DataTable SeleccionarTB(string codigo);//seleciona una tabla
        List<Dvd> Seleccionar(string codigo);//Selecionar Dvd
        Pais SeleccionarPais(string iso2);//Selecionar Pais
        //Delete
        int Borrar(string codigo);   
        //Update
        int Actualizar(Dvd unDVD);
        //Create
        int Insertar(Dvd unDVD);
    }
}
