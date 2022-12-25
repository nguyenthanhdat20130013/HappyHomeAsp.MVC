using MySql.Data.MySqlClient;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

namespace HappyHomeAsp.MVC.Models
{

    class CauHinh
    {

        public static MySqlConnection

                 GetDBConnection(string host, int port, string database, string username, string password)
        {

            /* Chuỗi kết nối trong thư viện MySql.Data.dll

            String connString = "Server=" + host + ";Database=" + database

              + ";port=" + port + ";User Id=" + username + ";password=" + password;*/

            string connString = "Server=" + host + ";Database=" + database + ";User=" + username

                + ";Port=" + port + ";Password=" + password + ";SSL Mode = None";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;

        }
    }
}