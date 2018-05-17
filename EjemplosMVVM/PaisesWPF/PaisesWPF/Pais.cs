using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaisesWPF
{
    class Pais
    {
       private string _nombre;       
       private string _name;
       private string _nom;
       private string _iso2;

       
       private string _iso3;   
       private string _phone_code;

       public string Name
       {
           get { return _name; }
           set { _name = value; }
       }
       public string Nom
       {
           get { return _nom; }
           set { _nom = value; }
       }
       public string Iso2
       {
           get { return _iso2; }
           set { _iso2 = value; }
       }
       public string Iso3
       {
           get { return _iso3; }
           set { _iso3 = value; }
       }
       public string Nombre
       {
           get { return _nombre; }
           set { _nombre = value; }
       }

       public string Phone_code
       {
           get { return _phone_code; }
           set { _phone_code = value; }
       }

    }
}
