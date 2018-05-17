using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//añadido
using System.ComponentModel;// Para implementar el interfaz INotifyPropertyChanged
using System.Windows.Input;//para los comandos
using CatalogoDVD_wpf;



namespace Catalogo2018
{
    class CatalogoVM:INotifyPropertyChanged //Clase intermedia o Vista Modelo(unifica la clase Dvd y Pais)
    {
        #region campos
        IDAO _dao;
        bool _tipoConexion = true;//Mysql: true, SQlite: false //Propiedad para asociarla con las propiedades de los controles del la UI (interfaz grafica)          
        List<Dvd> listado;
        Dvd _unDvd;
        string _mensaje = "<Sin datos>";//Propiedad para asociarla con las propiedades de los controles del la UI (interfaz grafica)       
        #endregion

        #region Propiedades

        public bool Conectado
        {
            get {
                if (_dao == null)
                    return false;
                else
                    return _dao.Conectado();
                }          
        }

        public string ColorConectar //Propiedad para cambiar el color del boton "Conectar" segun si se esta conectado o desconectado
        {

            get {
                if (Conectado)
                    return "green";
                else
                    return "red";
            }
            
            set 
            {
                NotificarcambioDepropiedad("ColorConectar");         
            }
        }

        public string Mensaje//Propiedad para cambiar el mensaje del lbestado 
        {
            get { return _mensaje; }
            set
            {
                if (_mensaje != value)
                {
                    _mensaje = value;
                    NotificarcambioDepropiedad("Mensaje");
                }
            }
        }

        public bool TipoConexion
        {
            get { return _tipoConexion; }
            set
            {
                if (_tipoConexion != value)
                {
                    _tipoConexion = value;
                    NotificarcambioDepropiedad("TipoConecxion");
                }

            }
        }

        public List<Dvd> Listado
        {
            get { return listado; }
            set
            {
                if (listado != value)
                {
                    listado = value;
                }
                NotificarcambioDepropiedad("Listado");
            }
        }

        public Dvd DvdSeleccionado//PENDIENTE
        {
            get { return _unDvd; }
            set
            {
                if (_unDvd != value)
                {                   
                    if (_dao.Conectado() && _unDvd != null)//El DVD dde donde sale??? se queda como NUll
                        Mensaje = _dao.SeleccionarPais(_unDvd.Pais).Nombre;
                    else
                        Mensaje = "<Desconocido>";


                    NotificarcambioDepropiedad("DVDSelecionadoNoNulo");
                }
                
            }
        }

        public bool DVDSelecionadoNoNulo
        {
            get { return DvdSeleccionado != null; }
        }

        #endregion

        #region Comandos
        //Todo comando  devuelve siempre void y no recibe parametros en este caso.

        
        public ICommand ConectarBD_click 
        {
            get 
            {
                //Clase RealeyCommand ( que implementa la interfaz Icommand)
                return new RelayCommand(o => ConectarBD(), o => true);//Llama al metodo conectarBD
            }
        }

        public ICommand DesconectarBD_click
        {
            get
            {
                //Clase RealeyCommand ( que implementa la interfaz Icommand)
                Listado = null;
                return new RelayCommand(o => DesconectarBD(), o => true);//Llama al metodo DesconectarBD
            }
        }

        public ICommand BorrarDVDBD_click
        {
            get
            {
                //Clase RealeyCommand ( que implementa la interfaz Icommand)               
                return new RelayCommand(o => BorrarDvd(), o => true);//Llama al metodo BorrarDvd Siempre de hay el true
            }
        }

        public ICommand ListarTodosDVD_Click
        {
            get
            {
                return new RelayCommand(o => ListarTodosDVD(), o => true); //este comando llama al metodo ListarTodosDVD
            }
        }

        private void ListarTodosDVD()
        {
            if (TipoConexion)
            {
                int nFilas = 0;
                Listado = _dao.SeleccionarPA(null, out nFilas);
                Mensaje = string.Format("Filas encontradas:{0}", nFilas);
            }
            else
            {
                Listado = _dao.Seleccionar(null);
                Mensaje = "Datos cargados...";
            }

        }
        /// <ConectarBDINFO>
        /// Comprueba si esta conectado y notifica los cambios a las propiedades que estan enlazadas con el UI
        /// </ConectarBDINFO>
        private void ConectarBD()
        {
            try
            {
                _dao = null;
                if (_tipoConexion)
                { //Trabjando con MYSQL
                    _dao = new DaoMysql();
                    _dao.Conectar("localhost", "3306", "catalogo", "root", "123");//Cambiar el usuario..  root no deberia estar..Q_Q  
                    Mensaje = "Conectado...";
                }
                else
                {
                    //trabajando con SQLITE
                    _dao = new DaoSqlite();
                    _dao.Conectar(null,null,"catalogo.db",null,null);//Cambiar el usuario..  root no deberia estar..Q_Q  
                    Mensaje = "Conectado con MySQLite";
                }
            }
            catch(Exception e)
            {
                Mensaje = e.Message;
            }
            NotificarcambioDepropiedad("ColorConectar");
            NotificarcambioDepropiedad("Conectado");
        }

        private void DesconectarBD()
        {
            _dao.Desconectar();          
            NotificarcambioDepropiedad("ColorConectar");
            NotificarcambioDepropiedad("Conectado");
            Mensaje = "Desconectado...";
        }

        private void BorrarDvd()
        { 
            if(DVDSelecionadoNoNulo) // Borro si u n Dvd selecionado no es nulo
            {
                if (_dao.Borrar(DvdSeleccionado.Codigo.ToString()) == 1)
                    Mensaje = "Registro eliminado";
                else
                    Mensaje = "Error al eliminar el registro";
            }
        }

        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotificarcambioDepropiedad(string propiedad)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;//Por pura aclaracion , no es necesario
            if (manejador != null)
                manejador(this, new PropertyChangedEventArgs(propiedad));
        }
        #endregion
    }
}
