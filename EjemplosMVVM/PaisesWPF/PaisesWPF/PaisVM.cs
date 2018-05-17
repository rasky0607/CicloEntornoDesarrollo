using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//añadido
using System.ComponentModel;//Espacio de nombre de notifyChanged

namespace PaisesWPF
{
    class PaisVM:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notificar(string propiedad)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if(manejador != null)
                manejador(this,new PropertyChangedEventArgs(propiedad));
        }

        DAO_Pais _dao;
        List<Pais> _listado;
        string _mensaje = "<na de na>";

        public string Mensaje
        {
            get { return _mensaje; }
            set
            {
                if (_mensaje != value)
                {
                    _mensaje = value;
                    Notificar("Mensaje");
                }
            }
        }

        public List<Pais> Listado
        {
            get { return _listado; }
            set
            {
                if (_listado != value)
                {
                    _listado = value;
                    Notificar("Listado");
                }
            
            }
        }

        private void ConnectBD()
        {
            try
            {
                _dao = new DAO_Pais();
                _dao.Connect("catalogo.db");
                Mensaje = "Conectado al catalogo en SQLite";
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
            }
        }

        private void SelectAllCountry()
        {
            Listado = _dao.Select();
            Mensaje = "Datos cargados...";
        }

        #region Command
        public RelayCommand Conectar_Click
        {
            get {
                return new RelayCommand(jojo => ConnectBD(), jojo => true);
            }
        }

        public RelayCommand Listar_Click
        {
            get
            {
                return new RelayCommand(jojo => SelectAllCountry(), jojo => true);
            }
        }
        #endregion



    }
}
