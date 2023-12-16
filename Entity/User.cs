using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class User
    { 
            private int userId;
            private string username;
            private string password;
            private string userType;

            // Constructors
            public User() { }

            public User(int userId, string username, string password, string userType)
            {
                this.userId = userId;
                this.username = username;
                this.password = password;
                this.userType = userType;
            }

            // Properties
            public int UserId { get => userId; set => userId = value; }
            public string Username { get => username; set => username = value; }
            public string Password { get => password; set => password = value; }
            public string UserType { get => userType; set => userType = value; }

            // ToString method
            public override string ToString()
            {
                return $"User{{userId={userId}, username='{username}', password='{password}', userType='{userType}'}}";
            }
        }
    }

