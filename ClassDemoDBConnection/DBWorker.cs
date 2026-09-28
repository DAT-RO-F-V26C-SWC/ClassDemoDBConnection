using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoDBConnection
{
    public class DBWorker
    {
        // instans felt
        SqlConnection _conn;

        public DBWorker() { }

        public void ConnectToDB()
        {
            // connection string
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=2semDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            // create connection
            _conn = new SqlConnection(connString);
            _conn.Open();
        }


        public void DisconnectFromDB()
        {
            _conn.Close();
        }


        public bool CheckUser(string user, string pass)
        {
            String sql = $"SELECT * FROM LoginDemo WHERE username='{user}' AND password='{pass}'";
            SqlCommand cmd = new SqlCommand(sql, _conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            
            return false;
        }

        private const String sqlCheck2 = $"SELECT * FROM LoginDemo WHERE username=@UserName AND password=@Password";
        public bool CheckUser2(string user, string pass)
        {
            DisconnectFromDB();
            ConnectToDB();
            
            SqlCommand cmd = new SqlCommand(sqlCheck2   , _conn);
            cmd.Parameters.AddWithValue("@UserName", user);
            cmd.Parameters.AddWithValue("@Password", pass);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }

            return false;
        }
    }
}
