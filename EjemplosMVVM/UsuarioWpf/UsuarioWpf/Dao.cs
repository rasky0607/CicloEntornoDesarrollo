using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//añadido
using System.Data.SQLite;
using System.Data;

namespace UsuarioWpf
{
    class Dao
    {
        SQLiteConnection conecxion;
        public bool Conectar()
        {
            string cadena = string.Format("Data Source=examen.db;Version=3;FailIfMissing=true;");
            conecxion = new SQLiteConnection(cadena);
            try
            {
                conecxion.Open();
                return true;
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void Desconectar()
        {
            conecxion.Close();
        }

        public bool Conectado()
        {
            if (conecxion != null)
                return conecxion.State == ConnectionState.Open;
            else
                return false;
        }

        public bool? SelecionarUsuario(string usuario, string contraseña)
        {
            string cadena = "select user,password,activo from usuario where user='" + usuario + "'";
            SQLiteCommand cmd = new SQLiteCommand(cadena, conecxion);
            SQLiteDataReader lector;
            try
            {
                lector = cmd.ExecuteReader();

                if (lector.HasRows)//Si el lector encontro datos deuvleve true si no false
                {
                    string nomtmp = string.Empty;
                    string passtmp = string.Empty;
                    int actitmp = 5;
                    while (lector.Read())
                    {
                        nomtmp = lector["user"].ToString();
                        passtmp = lector["password"].ToString();
                        actitmp = int.Parse(lector["activo"].ToString());
                        Usuario miusuario = new Usuario(nomtmp, passtmp, actitmp);
                    }
                    lector.Close();
                    if (contraseña == passtmp && actitmp == 1)//si coincide usuario con contraseña
                        return true;
                    if(contraseña == passtmp && actitmp == 0)//El usuario ya esta bloqueando de antes
                    return null;

                    return false;
                }
                else//si no encontro un usuario con ese nombre
                    return false;

            }
            catch
            {
                return false;
            }

        }

        public void Actualizar(string usuario)
        {
            try
            {
                string cadena = "update usuario SET activo=" + 0 + " where user='" + usuario + "';";
                SQLiteCommand cmd = new SQLiteCommand(cadena, conecxion);
                cmd.ExecuteNonQuery();
               
            }
            catch(SQLiteException e) {
                throw new Exception("ERROR " + e.Message);
            }
        }

    }
}


