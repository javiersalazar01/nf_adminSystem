using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
using System.Collections;
namespace nf_adminSystem
{
   public class PgConnector
    {
        private NpgsqlConnection con;
        private NpgsqlCommand comand;
        private static PgConnector util;
        private NpgsqlDataReader reader;
        private NpgsqlDataAdapter adapter;
        private DataSet ds;


        public static PgConnector getInstance()
        {
            if (util == null)
            {
                util = new PgConnector("Server=104.236.147.195;Port=5432;User Id=nf_admin;Password=csipronf;Database=nf_data;");
            }
            return util;
        }

        private PgConnector(string sConection)
        {
            try
            {
                con = new NpgsqlConnection(sConection);
                ds = new DataSet();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error no posible conectar a BD " + ex.Message);
            }
        }

        public NpgsqlConnection getConection()
        {
            return con;
        }


        /*
            utilicen este metodo para realizar consulas desde c#. sql es el string donde pondran la consulta
         * 
         * ejemplo: DataTable data = <obejto SQLConncetor>.consultar("select * from productos");
         * 
         * 
         */
        public DataTable consultar(string sql, string tabla)
        {
            try
            {
                con.Open();
                adapter = new NpgsqlDataAdapter(sql, con);
                if (!ds.Tables.Contains(tabla))
                {
                    adapter.Fill(ds, tabla);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error no se puede." + ex.Message + ex.StackTrace);
            }
            return ds.Tables[tabla];
        }

        public DataTable consultar(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                adapter = new NpgsqlDataAdapter(sql, con);
                adapter.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error no se puede." + ex.Message + ex.StackTrace);
            }
            return dt;
        }


        /*
            metodo encargado de realizar modificaciones a las tablas, desde c#, las sentencias update,insert y delete deben ser usadas en este metodo
         * ejemplo: bool res = <objeto sqlConncetor>.modificar("update clientes set nombre = 'panshito' where id = 1");
         * 
         */
        public bool modificar(string query)
        {
            bool res = true;
            try
            {
                con.Open();
                comand = con.CreateCommand();
                comand.CommandText = query;
                if (comand.ExecuteNonQuery() == -1)
                {
                    res = false;
                }
                con.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Imposible modificacion: " + ex.Message + ex.StackTrace);
            }
            return res;
        }


        /*
           ejecuta procedimeinto SIN parametros, y debuelve un DataSet con todas las tablas que arroja el procedimiento almacenado.
         * 
         * ejemplo:
         * HashTable params = new HashTable();
         * params.Add("paramName",paramValue)
         * 
         * ejecutarProcedimiento("dbo.<procedureName>",params)
         * 
         * 
        */

        public DataSet ejecutarProcedimiento(string procName)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = new DataSet();
                comand = con.CreateCommand();
                comand.CommandText = procName;
                comand.CommandType = CommandType.StoredProcedure;

                adapter = new NpgsqlDataAdapter(comand);
                adapter.Fill(ds);
            }
            catch (Exception e)
            {
                // MessageBox.Show("Un error a ocurrido: " + e.Message + e.StackTrace);
            }


            return ds;
        }

        /*
           ejecuta procedimeinto con parametros, y debuelve un DataSet con todas las tablas que arroja el procedimiento almacenado.
         * es incapas de funcionar con procedimientos con variables de salida.
         * 
         * ejemplo:
         * HashTable params = new HashTable();
         * params.Add("paramName",paramValue)
         * 
         * ejecutarProcedimiento("dbo.<procedureName>",params)
         * 
         * 
        */

        public bool nuevoUsuarioArea(string nombre, string pass, string mail, int userlevel, int institution_id, string llave, bool verified, int area_id)
        {
            con.Open();
            comand = con.CreateCommand();
            comand.CommandText = "nuevo_usuario_area";
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.AddWithValue("nombre", nombre);
            comand.Parameters.AddWithValue("pass", pass);
            comand.Parameters.AddWithValue("mail", mail);
            comand.Parameters.AddWithValue("userlevel", userlevel);
            comand.Parameters.AddWithValue("institution_id", institution_id);
            comand.Parameters.AddWithValue("key", llave);
            comand.Parameters.AddWithValue("verified", verified);
            comand.Parameters.AddWithValue("area_id", area_id);
            bool res = Convert.ToBoolean(comand.ExecuteScalar());
            
            con.Close();
            return res;
        }

        public bool nuevoUsuarioSubArea(string nombre, string pass, string mail, int userlevel, int institution_id, string llave, bool verified, int subarea_id, int area_id)
        {
            con.Open();
            comand = con.CreateCommand();
            comand.CommandText = "nuevo_usuario_subarea";
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.AddWithValue("nombre", nombre);
            comand.Parameters.AddWithValue("pass", pass);
            comand.Parameters.AddWithValue("mail", mail);
            comand.Parameters.AddWithValue("userlevel", userlevel);
            comand.Parameters.AddWithValue("institution_id", institution_id);
            comand.Parameters.AddWithValue("key", llave);
            comand.Parameters.AddWithValue("verified", verified);
            comand.Parameters.AddWithValue("subarea_id", subarea_id);
            comand.Parameters.AddWithValue("area_id", area_id);
            bool res = Convert.ToBoolean(comand.ExecuteScalar());
            
            con.Close();
            return res;
        }
        
        public DataSet ejecutarProcedimiento(string procName, Hashtable parameters)
        {
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                ds = new DataSet();
                comand = con.CreateCommand();
                comand.CommandText = procName;
                comand.CommandType = CommandType.StoredProcedure;

                foreach (DictionaryEntry pair in parameters)
                {
                    comand.Parameters.AddWithValue(Convert.ToString(pair.Key), pair.Value);
                }

                comand.ExecuteNonQuery();
                adapter = new NpgsqlDataAdapter(comand);
                adapter.Fill(ds);

            }
            catch (Exception e)
            {

                //MessageBox.Show("Un error a ocurrido: " + e.Message + e.StackTrace);
            }
            con.Close();
            return ds;
        }

        public object ejecutarEscalar(string sql)
        {
            object res = "null";
            try
            {
                con.Open();
                comand = con.CreateCommand();
                comand.CommandText = sql;
                res = comand.ExecuteScalar();
                con.Close();

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error no se puede." + ex.Message + ex.StackTrace);
            }

            return res;
        }
    }
}
