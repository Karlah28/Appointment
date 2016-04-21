using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Web.Security;

namespace AppointmentScheduler.App_Start
{
    public class DatabaseStartup
    {
        //static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString;
     //  static MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
 
       

//using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
        //MySqlConnection connection = new MySqlConnection("Server=yhg4p5n9os.database.windows.net,1433;Database=Appointments;UID=georoni@yhg4p5n9os;Password=QpalzM728;Encrypt=True;Connection Timeout=30;");
        static string ConnectionString = @"Server=yhg4p5n9os.database.windows.net,1433;Database=Appointments;UID=georoni@yhg4p5n9os;Password=QpalzM728;Encrypt=True;Connection Timeout=30;";

        // connect to local sql server
        SqlConnection connection = new SqlConnection(ConnectionString);



        public void Init(){
            //conn_string.Server = "yhg4p5n9os.database.windows.net";
            //conn_string.UserID = "georoni";
            //conn_string.Password = "QpalzM728";
            //conn_string.Database = "Appointments";
            //OpenConnection();
            CleanUpRoles();
            CreateRoles();


            CloseConnection();
        }


        private void CreateRoles()
        {
            string superAdminQuery = "INSERT INTO dbo.Roles(RoleId, Name) VALUES('SuperAdmin', '1')";
            string adminQuery = "INSERT INTO dbo.Roles(RoleId, Name) VALUES('Admin', '2')";
            string customerQuery = "INSERT INTO dbo.Roles(RoleId, Name) VALUES('Customer', '3')";
            string providerQuery = "INSERT INTO dbo.Roles(RoleId, Name) VALUES('Provider', '4')";
            string createUserQuery = "INSERT INTO dbo.Users(UserName, Email, PasswordHash) VALUES ('Admin', 'AdminPassword')";

           // var conn = connection.Open();
            //open connection
            connection.Open();
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    SqlCommand superAdminCmd = new SqlCommand(superAdminQuery, connection);
                    SqlCommand adminCmd = new SqlCommand(adminQuery, connection);
                    SqlCommand customerCmd = new SqlCommand(customerQuery, connection);
                    SqlCommand providerCmd = new SqlCommand(providerQuery, connection);
                   // SqlCommand createUserCmd = new SqlCommand(createUserQuery, connection);


                    //Execute command
                    superAdminCmd.ExecuteNonQuery();
                    adminCmd.ExecuteNonQuery();
                    customerCmd.ExecuteNonQuery();
                    providerCmd.ExecuteNonQuery();
                    //createUserCmd.ExecuteNonQuery();
                    connection.Close();
                    //close connection
                    //this.CloseConnection();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.StackTrace);
                }
            }
        }

        private void CleanUpRoles()
        {
            string query = "DELETE from dbo.Roles";
            //var conn = connection.Open();
            //open connection
            connection.Open();
           
                //create command and assign the query and connection from the constructor
                SqlCommand cmd = new SqlCommand(query, connection);
               
                //Execute command
                cmd.ExecuteNonQuery();

                connection.Close();
 
            
        }

        private void CloseConnection()
        {
            this.connection.Close();
        }
       
    }

}