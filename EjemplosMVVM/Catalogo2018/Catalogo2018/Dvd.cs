using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CatalogoDVD_wpf
{
    public class Dvd
    {
        #region Campos
        private int _codigo;
        private string _titulo;
        private string _artista;
        private string _anio;
        private string _pais;
        private string _compania;
        private double _precio;
        #endregion

        #region Propiedades
        public string Artista
        {
            get { return _artista; }
            set { _artista = value; }
        }
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }
        public string Compania
        {
            get { return _compania; }
            set { _compania = value; }
        }
        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public string Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }
        #endregion

        #region Métodos sobreescritos
        public override string ToString()
        {
            return _codigo.ToString() + ", " + _titulo + ", " + _artista + ", " + _pais
                + ", " + _compania + ", " + _precio + ", " + _anio;
        }

        #endregion


        //public ListadoDVD.ItemEndEditEventHandler ItemEndEdit { get; set; }
    }
}
