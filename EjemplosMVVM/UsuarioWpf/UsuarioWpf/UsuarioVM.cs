using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//añadido
using System.ComponentModel;

namespace UsuarioWpf
{
    class UsuarioVM : INotifyPropertyChanged
    {
       
        #region Campos
        int _nintentos = 3;     
        string _mensaje = "<na na na>";
        string _tbxUser;
        string _tbxPassword;//Coge los valores del textobox
        Usuario miusuario;
        Dao midao;
        #endregion

        #region Propiedades
        public string TbxUser//Propiedad Bindeada a la propiedad text de el TexBox tbx_User
        {
            get { return _tbxUser; }
            set { _tbxUser = value; }
        }

        public string TbxPassword//Propiedad Bindeada a la propiedad text de el TexBox tbx_pass
        {
            get { return _tbxPassword; }
            set {_tbxPassword = value; }
        }

        public int Nintentos
        {
            get { return _nintentos; }
            set
            {
                if (_nintentos != value)
                {
                    _nintentos = value;
                }
                Notificador("Mensaje");
            }
        }
 
        public string Mensaje//Propiedad Bindeada a la propiedad text de el lbmensaje
        {
            get { return _mensaje; }
            set
            {
                if (_mensaje != value)
                    _mensaje = value;
                Notificador("Mensaje");
            }
        } 

        #endregion

        #region Command

        private void Login()
        {
            try
            {
                if (Nintentos > 0)
                {
                    miusuario = new Usuario(TbxUser, TbxPassword);
                    midao = new Dao();
                    midao.Conectar();
                    if (midao.SelecionarUsuario(miusuario.User, miusuario.Password) == true)//Si devuelve True es por que el campo Activo esta a 1
                        Mensaje = "Estas dentro";
                    else if ((midao.SelecionarUsuario(miusuario.User, miusuario.Password)) == null)//Si devuelve nulo es por que el campo Activo esta a 0
                        {
                        Mensaje = "Esta usuario esta bloqueado!";
                    }
                    else//Si devuelve False es por que no esta en la BD
                    {
                        Nintentos--;
                        Mensaje = "Te quedan " + Nintentos + " intentos.";
                    }
                }
                else// bloqueo el usuario
                {
                    midao.Actualizar(miusuario.User);
                    Mensaje ="Estas bloqueado!";
                }
            }
            catch
            {

            }
        }
        public RelayCommand Conectar_Click //Propiedad Bindeada a la propiedad Command de btn_Login
        {
            get
            {
                return new RelayCommand(ellogin => Login(),ellogin=>true);
            }
        }
        #endregion

        #region Implementacion de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notificador(string propiedad)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }
        #endregion
    }
}
