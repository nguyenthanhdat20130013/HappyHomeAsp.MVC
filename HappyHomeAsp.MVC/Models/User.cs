using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HappyHomeAsp.MVC.Models
{
        public class User
        {
            private int id;
            private String userName;
            private String passWord;
            private String fullName;
            private String phoneNum;
            private String email;
            private String address;
            private String gender;
            private String img;
            private int status;
            private int role;

        public User() { }
            public User(int id, string userName, string passWord, string fullName, string phoneNum, String email, string address, string gender, string img,int status, int role)
        {
            this.Id = id;
            this.UserName = userName;
            this.PassWord = passWord;
            this.FullName = fullName;
            this.PhoneNum = phoneNum;
            this.Email = email;
            this.Address = address;
            this.Gender = gender;
            this.Img = img;
            this.Status = status;
            this.Role = role;
        }

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Img { get => img; set => img = value; }
        public int Status { get => status; set => status = value; }
        public int Role { get => role; set => role = value; }
    }
}
