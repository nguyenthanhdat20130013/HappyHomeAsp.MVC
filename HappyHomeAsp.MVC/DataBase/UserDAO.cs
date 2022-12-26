using HappyHomeAsp.MVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HappyHomeAsp.MVC.DataBase
{
    public class UserDAO
    {
        public static User findUser(String userName, String passWord)
        {
            User user = null;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select * from user u inner join account a on u.id = a.user_id  where u.user_name = @param_val_1 and u.password = @param_val_2";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", userName);
                    cmd.Parameters.AddWithValue("@param_val_2", passWord);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            user = new User(Convert.ToInt32(sdr["id"]), sdr["user_name"].ToString(),
                                 sdr["password"].ToString(), sdr["full_name"].ToString(), sdr["phone_num"].ToString(),
                                 sdr["email"].ToString(), sdr["address"].ToString(), sdr["gender"].ToString(), sdr["img"].ToString(), Convert.ToInt32(sdr["status"]), Convert.ToInt32(sdr["role"]));
                        }
                    }
                    con.Close();
                }
            }
            return user;
        }
        public static User findUserAdmin(String userName, String passWord)
        {
            User user = null;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select * from user where user_name = @param_val_1 and password = @param_val_2";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", userName);
                    cmd.Parameters.AddWithValue("@param_val_2", passWord);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            user = new User(Convert.ToInt32(sdr["id"]), sdr["user_name"].ToString(),
                                 sdr["password"].ToString(),"","","","","","",1,1);
                        }
                    }
                    con.Close();
                }
            }
            return user;
        }

        public static User findUserById(int id)
        {
            User user = null;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select * from user u inner join account a on u.id = a.user_id where id = @param_val_1";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", id);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            user = new User(Convert.ToInt32(sdr["id"]), sdr["user_name"].ToString(), 
                                sdr["password"].ToString(),sdr["full_name"].ToString(), sdr["phone_num"].ToString(),
                                sdr["email"].ToString(), sdr["address"].ToString(), sdr["gender"].ToString(), sdr["img"].ToString(), Convert.ToInt32(sdr["status"]), Convert.ToInt32(sdr["role"]));
                        }
                    }
                    con.Close();
                }
            }
            return user;
        }

        public static void updateUser(int id,String passWord, String fullName, String email, String phoneNum, String address)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                string query = "update user u " +
                    "inner join account a on u.id = a.user_id " +
                    "set u.password = @param_val_1, a.full_name = @param_val_2, a.email = @param_val_3 , a.phone_num = @param_val_4, a.address = @param_val_5 where u.id = @param_val_6; ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", passWord);
                    cmd.Parameters.AddWithValue("@param_val_2", fullName);
                    cmd.Parameters.AddWithValue("@param_val_3", email);
                    cmd.Parameters.AddWithValue("@param_val_4", phoneNum);
                    cmd.Parameters.AddWithValue("@param_val_5", address);
                    cmd.Parameters.AddWithValue("@param_val_6", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                
            }
        }

        public static void updateUserAdmin(int id, String userName, String passWord, int role)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                string query = "update user u " +
                    "inner join account a on u.id = a.user_id " +
                    "set u.user_name = @param_val_1, u.password = @param_val_2, u.role = @param_val_3 where u.id = @param_val_4 ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", userName);
                    cmd.Parameters.AddWithValue("@param_val_2", passWord);
                    cmd.Parameters.AddWithValue("@param_val_3", role);
                    cmd.Parameters.AddWithValue("@param_val_4", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
        }

        public static void addUserAdmin(User user)
        {
            int role = user.Role;
            String username = user.UserName;
            String password = user.PassWord;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                string query = "insert into user(user_name,password,role) values(@param_val_1,@param_val_2,@param_val_3)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", user.UserName);
                    cmd.Parameters.AddWithValue("@param_val_2", user.PassWord);
                    cmd.Parameters.AddWithValue("@param_val_3", user.Role);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }            
            }
            User userAcc = UserDAO.findUserAdmin(username, password);
            addAccountUserAdmin(userAcc);
        }

        public static void addAccountUserAdmin(User user)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                string query = "insert into account(user_id) values(@param_val_1)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", user.Id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
        }


        public static void deleteUserAdmin(int id)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                string query = "DELETE a FROM user u " +
                              "JOIN account a ON u.id = a.user_id " +
                              "WHERE u.id = @param_val_1 ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@param_val_1", id);     
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public static List<User> findAll()
        {
            List<User> users = new List<User>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select * from user u inner join account a on u.id = a.user_id";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            users.Add(new User(Convert.ToInt32(sdr["id"]), sdr["user_name"].ToString(),
                                 sdr["password"].ToString(),"","","","","","",1,1));
                        }
                    }
                    con.Close();
                }
            }
            return users;
        }
    }
}
