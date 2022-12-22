using HappyHomeAsp.MVC.Models;
using MySql.Data.MySqlClient;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

namespace HappyHomeAsp.MVC.Models
{

    class KetNoi
    {

        public static MySqlConnection GetDBConnection()
        {

            //string host = "127.0.0.1";

            string host = "localhost";

            int port = 3306;

            string database = "shophappyhome"; ;

            string username = "root";

            string password = "";

            /*khởi tạo các thành phần để phục vụ cho việc kết nối cơ sở dữ liệu mysql cụ thể là phpmyadmin*/

            return CauHinh.GetDBConnection(host, port, database, username, password);

        }
    }
}