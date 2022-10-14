using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntroductionToCSharp
{
    /// <summary>
    /// Interaction logic for Members.xaml
    /// </summary>
    public partial class Members : UserControl
    {
        const string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_revsystem;";

        public Members()
        {

            InitializeComponent();
            getBgy();
            getList();
        }

        public class User
        {
            public int ID { get; set; }
            public string FN { get; set; }
            public string MN { get; set; }
            public string LN { get; set; }
            public string gender { get; set; }
            public string houseNum { get; set; }
            public string barangay { get; set; }
        }

        public void getList()
        {

            ListOfWalkIn.Items.Clear();
            string query = "call getCustomer()";

            MySqlConnection databaseConnection = new MySqlConnection(conn);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User _tmpUser = new User
                        {
                            ID = reader.GetInt32(0),
                            FN = reader.GetString(1),
                            MN = reader.GetString(2),
                            LN = reader.GetString(3),
                            gender = reader.GetString(4),
                            houseNum = reader.GetString(5),
                            barangay = reader.GetString(6)


                        };
                        ListOfWalkIn.Items.Add(_tmpUser);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void getBgy()
        {


            string query = "call getBarangay()";

            MySqlConnection databaseConnection = new MySqlConnection(conn);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    string bgy = reader.GetString("bgy_name");
                    c_bgy.Items.Add(bgy);
                }
                // Success, now list 
                databaseConnection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void AddWalkCus_Click(object sender, RoutedEventArgs e)
        {



            IntroductionToCSharp.Modules.addMember add = new IntroductionToCSharp.Modules.addMember();

            string fn = c_firstName.Text;
            string ln = c_lastName.Text;
            string mn = c_middleName.Text;
            string hn = c_houseNumber.Text;
            int bgy = c_bgy.SelectedIndex + 1;
            if (c_genderMale.IsChecked == true)
            {
                string gender = c_genderMale.Content.ToString();

                add.AddMember(fn, mn, ln, hn, 1, bgy, 0);
                getList();
            }
            else
            {
                string gender = c_genderFemale.Content.ToString();
                add.AddMember(fn, mn, ln, hn, 2, bgy, 0);
                getList();
            }



        }

        private void ListOfWalkIn_Loaded(object sender, RoutedEventArgs e)
        {

            ListOfWalkIn.Items.Clear();

            string query = "call getCustomer()";

            MySqlConnection databaseConnection = new MySqlConnection(conn);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // Success, now list 
                databaseConnection.Close();
                getList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
