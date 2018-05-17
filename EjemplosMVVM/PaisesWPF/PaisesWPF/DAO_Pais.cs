using System;
using System.Collections.Generic;
//añadido
using System.Data.SQLite;

namespace PaisesWPF
{
    class DAO_Pais
    {
        private SQLiteConnection conecxion;
        

        public bool Connect(string db)
        {
            string cadena = String.Format("Data Source={0};Version=3;FailIfMissing=true;", db);
            conecxion = new SQLiteConnection(cadena);
            try
            {
                conecxion.Open();
                return true;

            }
            catch(SQLiteException e) 
            {
                throw new Exception("Error: "+e.Data);
            }
           
        }

        public bool Connected()
        {
            if (conecxion != null)
                return conecxion.State == System.Data.ConnectionState.Open;
            else
                return false;
        }

        public List<Pais> Select()
        {
            List<Pais> resultado = new List<Pais>();
            SQLiteCommand cmd = new SQLiteCommand("select * from pais", conecxion);

            try
            {
                SQLiteDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Pais p = new Pais();
                    p.Iso2 = lector["Iso2"].ToString();
                    p.Iso3 = lector["Iso3"].ToString();
                    p.Name = lector["Name"].ToString();
                    p.Nom = lector["Nom"].ToString();
                    p.Nombre = lector["Nombre"].ToString();
                    p.Phone_code = lector["Phone_code"].ToString();

                    resultado.Add(p);
                }
                lector.Close();
            }
            catch (SQLiteException e)
            {
                throw new Exception("ERROR en el select :" + e.Data);
            }
            return resultado;
        }
    }
}
