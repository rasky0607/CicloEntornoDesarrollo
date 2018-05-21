using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UsuarioWpf
{
    class Usuario
    {
        #region Campo
        string _user;
        string _password;
        int _activo;
        #endregion

        #region Propiedades
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        #endregion

        #region Constructor
        public Usuario()
        {

        }
        public Usuario(string nom, string pass,int act)
        {
            User = nom;
            Password = pass;
            Activo = act;
         }
        public Usuario(string nom, string pass)
        {
            User = nom;
            Password = pass;
           
        }
        #endregion
    }
}
