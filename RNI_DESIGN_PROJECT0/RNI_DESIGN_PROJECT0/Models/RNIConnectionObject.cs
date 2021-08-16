using System;
using System.Collections.Generic;
using System.Text;
using RNI_DESIGN_PROJECT0.Models;
using MySqlConnector;

namespace RNI_DESIGN_PROJECT0.Models
{
    class RNIConnectionObject
    {
        public static ConnectToRNIDatabase temp = null;
        private static bool logged_in = false;
        public static string current_user_first_name = "";
        public static void create_connection_object(int userid) {
            temp = new ConnectToRNIDatabase(userid);
            temp.public_command.CommandText = $"Select first_name FROM users_information WHERE account_id = '{temp.user_id}';";
            MySqlDataReader reader = temp.public_command.ExecuteReader();
            while (reader.Read())
            {
                current_user_first_name = reader.GetString("first_name");
            }
            
        }

        public static void kill_connection_object() {
            logged_in = false;
            if (temp != null) {
                temp.closeConnection();
                temp = null;
            }
        }

        public static bool Logged_In
        {
            get { return logged_in; }
            set { logged_in = value;}
        }

    }
}
