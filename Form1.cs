using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            string Fname;
            Fname = First_Name.Text;
            string Lname;
            Lname = Last_Name.Text;
            string A;
            A = Age.Text;
            string Uid;
            Uid = UserID.Text;
            string Pword;
            Pword = Password.Text;

            //String to be passed into the connection object with all the needed data to open connection with MySql
            string connectionDetails = "datasource = ipAddress; Port = 3306; Database = database name; Uid = userid; Pwd = password";

            //Instantiate MySqlConnection Object https://dev.mysql.com/doc/dev/connector-net/6.10/html/T_MySql_Data_MySqlClient_MySqlConnection.htm
            MySqlConnection connection = new MySqlConnection(connectionDetails);

            //Command class https://dev.mysql.com/doc/dev/connector-net/6.10/html/T_MySql_Data_MySqlClient_MySqlConnection.htm  
            MySqlCommand myCommand = new MySqlCommand();

            try
            {
                //Opens a database connection with the property settings specified by the ConnectionString
                connection.Open();

                Console.WriteLine("Opened Connection");
                Console.WriteLine("Preparing to write data to table");

                myCommand = connection.CreateCommand();
                myCommand.CommandText = "INSERT INTO clientinfo(firstname, lastname, age, userid, password)VALUES(@firstname, @lastname, @age, @userid, @password)";
                myCommand.Parameters.AddWithValue("@firstname", Fname);
                myCommand.Parameters.AddWithValue("@lastname", Lname);
                myCommand.Parameters.AddWithValue("@age", A);
                myCommand.Parameters.AddWithValue("@userid", Uid);
                myCommand.Parameters.AddWithValue("@password", Pword);

                //execute a command that will not return any data
                myCommand.ExecuteNonQuery();

                Console.WriteLine("Table updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Closing Connection");
                connection.Close();
            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void First_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Last_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Age_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UserID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
