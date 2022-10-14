
using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace IntroductionToCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string password;
        private static string username;



        public string Password   // property
        {
            get { return password; }
            set { password = value; }
        }

        public string Username   // property
        {
            get { return username; }
            set { username = value; }
        }
        public MainWindow()
        {
            InitializeComponent();



        }



        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {

            loggingIn();
        }

        public void loggingIn()
        {
            MainWindow main = new MainWindow();

            main.Username = UserTxtbox.Text;
            main.Password = Passwordbx.Password;


            string plainData = main.Password;
            string hashedData = ComputeSha256Hash(plainData);

            const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_revsystem;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            if (main.Username == "" && main.Password == "")
            {
                MessageBox.Show("Input Username and Password");
            }
            else
            {
                try
                {
                    MySqlCommand commandDatabase = new MySqlCommand("SELECT * from tbl_account WHERE a_user = '" + main.Username + "' AND userHash = '" + hashedData + "'", databaseConnection);
                    MySqlDataReader reader;
                    reader = commandDatabase.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {


                        LandingWindow load = new LandingWindow();
                        load.Show();
                        Hide();


                    }
                    else
                    {
                        MessageBox.Show("Username and password did not match!");
                    }
                    main.Username = "";
                    main.Password = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Passwordbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                loggingIn();

            }
        }

        private void UserTxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                loggingIn();

            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
