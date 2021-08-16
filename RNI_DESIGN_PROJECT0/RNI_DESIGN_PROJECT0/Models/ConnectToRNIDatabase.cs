using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace RNI_DESIGN_PROJECT0.Models
{
    class ConnectToRNIDatabase
    {
        const string connString = "Server=rni-test-2.cogwibtpdpoi.us-east-2.rds.amazonaws.com;Port=3306;Database=Example_Login_Information;Uid=admin;password=Lemonpez82";
        const string ACCOUNT_ID = "account_id";
        const string FIRST_NAME = "first_name";
        const string LAST_NAME = "last_name";
        const string EMAIL_ADDRESS = "email_address";
        const string ACCOUNT_USERNAME = "account_username";
        const string ACCOUNT_PASSWORD = "account_password";
        const string GPA = "gpa";

        public int user_id;
        public MySqlConnection public_conn;
        public MySqlCommand public_command;

        public ConnectToRNIDatabase(int user_id_param) {
            user_id = user_id_param;
            public_conn = new MySqlConnection(connString);
            public_command = public_conn.CreateCommand();
            try
            {
                public_conn.Open();
            }
            catch (Exception ex)
            {
                //figure it out later
            }

        }


        public void closeConnection() {
            public_conn.Close();
        }
        public static bool Correct_Email_And_Password(string par_email_address, string par_password) {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = $"SELECT account_password FROM users_information WHERE email_address = '{par_email_address}';";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Server is down or bad server connection");
                return false;
            }
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                if (reader.GetString(ACCOUNT_PASSWORD).Equals(par_password))
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

        public static int get_user_id(string par_email_address, string par_password) {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = $"SELECT account_id FROM users_information WHERE email_address = '{par_email_address}' AND account_password = '{par_password}';";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Server is down or bad server connection");
                return 0;
            }
            int temp = 0;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temp = reader.GetInt32(ACCOUNT_ID);
            }
            conn.Close();
            return temp;
        }
        public static bool Create_New_Account(string first_name, string last_name, string account_username, string par_email_address, string par_password)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = $"INSERT INTO users_information (first_name,last_name, email_address, account_username, account_password)VALUES('{first_name}', '{last_name}','{par_email_address}', '{account_username}', '{par_password}');";
            try
            {
                conn.Open();
                command.ExecuteNonQueryAsync();
            }
            catch
            {
               // Console.WriteLine(ex.Message);
               // Console.WriteLine("Server is down or bad server connection");
                return false;
            }
            
            conn.Close();
            return true;
        }

    }

    



}

