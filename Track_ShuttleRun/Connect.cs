using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Configuration;


namespace Track_ShuttleRun
{
    class Connect
    {
        private MySqlCommand cmd = new MySqlCommand();

        //Connect Database
        //private string cfg = $"Server=192.168.1.78;Port=3306;UID=lms;PWD=ServerDev@2021;Database=shuttle_run";
        //private string cfg = $"Server=localhost;Port=3306;UID=root;PWD=;Database=shuttle_run";
        private string cfg = System.Configuration.ConfigurationManager.AppSettings["connectionDB"];

        private MySqlConnection con = new MySqlConnection();

        public Connect()
        {
            con.ConnectionString = cfg;
        }

        public DataTable getTable(string sql)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                data.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Menampilkan Data " + ex.Message);
            }

            return dt;
        }

        public DataSet GetData(string sql, string namatabel)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                data.Fill(ds, namatabel);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Gagal Menampilkan Data " + e.Message);
            }

            return ds;
        }

        public bool execute(String sql)
        {
            bool stat = false;
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                stat = true;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                stat = false;
                //MessageBox.Show("Gagal dalam eksekusi query " + e.Message, "Warning   222222222222222");
            }
            return stat;
        }

        public long insert(string sql)
        {
            long stat = 0;
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                stat = cmd.LastInsertedId;
                con.Close();
            }
            catch (Exception e)
            {
                stat = 0;
                MessageBox.Show("Gagal dalam eksekusi query " + e.Message, "Warning");
            }
            return stat;
        }

        public bool search(String sql)
        {
            bool stat = false;
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                MySqlDataReader cari = cmd.ExecuteReader();
                if (cari.Read())
                {
                    con.Close();
                    stat = true;
                }
                else
                {
                    con.Close();
                    stat = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Gagal dalam mencari data ");
            }
            return stat;
        }



    }
}
