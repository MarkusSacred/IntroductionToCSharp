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
    /// Interaction logic for isDeleteWPF.xaml
    /// </summary>
    public partial class isDeleteWPF : UserControl
    {

        User currUser = null;
        public isDeleteWPF()
        {
            InitializeComponent();
            getBgy();

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

        const string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_revsystem;";


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
                            houseNum = reader.GetString(4),
                            gender = reader.GetString(5),
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

        private void ListOfWalkIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListOfWalkIn.SelectedIndex > -1)
            {

                currUser = (User)ListOfWalkIn.SelectedItem;

                c_id.Content = currUser.ID.ToString();
                c_firstName.Text = currUser.FN;
                c_middleName.Text = currUser.MN;
                c_lastName.Text = currUser.LN;
                c_houseNumber.Text = currUser.houseNum;
                if (currUser.gender == "Male")
                {
                    c_genderMale.IsChecked = true;
                }
                else
                {
                    c_genderFemale.IsChecked = true;
                }

                c_bgy.SelectedItem = currUser.barangay;

            }


        }

        private void idDelete_Click(object sender, RoutedEventArgs e)
        {
            IntroductionToCSharp.Modules.delMember del = new IntroductionToCSharp.Modules.delMember();
            int id = Convert.ToInt32(c_id.Content);
            del.delMembers(id);
            getList();
            c_id.Content = "";
            c_firstName.Text = "";
            c_middleName.Text = "";
            c_lastName.Text = "";
            c_houseNumber.Text = "";
            c_genderMale.IsChecked = true;
            c_bgy.SelectedIndex = 0;

        }
    }
}
