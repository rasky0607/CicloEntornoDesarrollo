using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//añadir
using System.Data.SQLite;
using System.Data;
using  CatalogoDVD_wpf;

namespace Catalogo2018
{
    class DaoSqlite:IDAO
    {
        #region conecxion a la BD y desconecxion
        public SQLiteConnection conexion;
        public bool Conectar(string srv, string port, string db, string user, string pwd)
        {
            string cadenaConexion = string.Format("Data Source={0};Version=3;FailIMissing=true;",db);

            try
            {
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open();
                return true;
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error de conecxion" + e.Data);
            }

        }

        public void Desconectar()
        {
            try
            {
                conexion.Close();
            }
            catch
            {

            }
        }
        #endregion

        //Comprueba la conecxion
        public bool Conectado()
        {
            if (conexion != null)
                return conexion.State == ConnectionState.Open;
            else
                return false;

        }

        #region Selecionar
        //Usando colecciones
        public List<Dvd> Seleccionar(string codigo)
        {
            List<Dvd> resultado = new List<Dvd>();
            string orden;
            if (codigo == null)
                orden = "select codigo,titulo,artista,pais,compania,precio,anio from dvd";
            else
                orden = "select codigo,titulo,artista,pais,compania,precio,anio from dvd where codigo='" + codigo + "'";
            SQLiteCommand cmd = new SQLiteCommand(orden, conexion);//construcion del comando
            SQLiteDataReader lector = null;

            try
            {
                lector = cmd.ExecuteReader();//recoge y lee los datos de la consulta fila a fila
                //cmd.ExecuteNonQuery();//cuando la consulta efectuada hacia la BD no es un select( como por ejemplo un update , insert etc..)
                //cmd.ExecuteScalar();//cuando la consulta efectuada hacia la BD no devuelve una coleccion.o solo cuando recogemos un unico numero

                while (lector.Read())//Mientras hay algo que leer , recogemos cada uno de los datos en cada uno de los campos.//Cuando devuelva un lectro devuelva  falso o emty set lectura vacia, saldra del bucle
                {
                    Dvd undvd = new Dvd();
                    //Esto se realiza una vez por cada linea que lee
                    undvd.Codigo = int.Parse(lector["codigo"].ToString());
                    undvd.Titulo = lector["titulo"].ToString();
                    undvd.Artista = lector["artista"].ToString();
                    undvd.Pais = lector["pais"].ToString();
                    undvd.Compania = lector["compania"].ToString();
                    undvd.Precio = double.Parse(lector["precio"].ToString());
                    undvd.Anio = lector["anio"].ToString();
                    resultado.Add(undvd);//añado un dvd a la lista
                }
                return resultado;

            }
            catch (SQLiteException)
            {
                throw new Exception("No tiene permisos para ejecutar esta orden");
            }
            finally
            {
                if (lector != null)
                    lector.Close();//Cierra el flujo
            }

        }

        //Seleciona con una tabla osea "Usando tablas o datatable en lugar de coleciones para recoger los datos"
        public DataTable SeleccionarTB(string codigo)
        {
            DataTable dt = new DataTable();
            string orden;
            if (codigo == null)
                orden = "select codigo,titulo,artista,pais,compania,precio,anio from dvd";
            else
                orden = "select codigo,titulo,artista,pais,compania,precio,anio from dvd where codigo='" + codigo + "'";
            SQLiteCommand cmd = new SQLiteCommand(orden, conexion);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);//Adaptador de datos
            da.Fill(dt);//el adaptador rellena el datatable con los datos del que obtubo el comando adaptado por el dataadapter

            return dt;
        }

        //Procedimiento Almacenados
        public List<Dvd> SeleccionarPA(string codi, out int resul)//**OJO** resul variable donde voy a recoger el Parametro de salida del PA "out-> por valor y se inicializa en el mismo momento que se crea
        {
            throw new NotImplementedException();
        }

        public Pais SeleccionarPais(string iso2)//PENDIENTE REVISION
        {
            Pais resultado = new Pais();
            string orden;
            orden = string.Format("select nombre from pais where iso2 = '{0}'", iso2);
            SQLiteCommand cmd = new SQLiteCommand(orden, conexion);
            object salida = cmd.ExecuteScalar();
            if (salida != null)
            {
                resultado.Iso2 = iso2;
                resultado.Nombre = salida.ToString();
            }
            return resultado;
        }

        #endregion

        #region Borrado, Actualizacion, insercion
        public int Borrar(string codigo)
        {
            string orden;
            if (codigo != null)
            {
                orden = string.Format("delete from dvd where codigo = '{0}'", codigo);
                SQLiteCommand cmd = new SQLiteCommand(orden, conexion);
                return cmd.ExecuteNonQuery();
            }
            else
                return -1;
        }

        public int Actualizar(Dvd unDVD)
        {
            string orden;

            if (unDVD != null)
            {
                orden = string.Format("update dvd set titulo='{0}',artista='{1}',pais='{2}',compania='{3}',precio={4},anio='{5}' where codigo = {6}", unDVD.Titulo, unDVD.Artista, unDVD.Pais, unDVD.Compania, unDVD.Precio, unDVD.Anio, unDVD.Codigo);
                SQLiteCommand cmd = new SQLiteCommand(orden, conexion);
                return cmd.ExecuteNonQuery();
            }
            else
                return -1;
        }

        public int Insertar(Dvd unDVD)
        {
            string orden;
            if (unDVD != null)
            {
                orden = string.Format("insert into dvd (codigo,titulo,artista,pais,compania,precio,anio)" + " values ('{0}','{1}','{2}','{3}','{4}',{5},'{6}')", unDVD.Codigo, unDVD.Titulo, unDVD.Artista, unDVD.Pais, unDVD.Compania, unDVD.Precio, unDVD.Anio);
                SQLiteCommand cmd = new SQLiteCommand(orden, conexion);
                return cmd.ExecuteNonQuery();
            }
            else
                return -1;
        }
        #endregion
    }

}
