using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntroductionToCSharp.Modules
{
    public class upMember : Members
    {

        const string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_revsystem;";


        public void AddMember(string firstName, string midleName, string lastName, string houseNumber, int gender, int brgy, int isDel)
        {



            string getMembers = "INSERT INTO `tbl_members`(`firstName`, `middleName`, `lastName`, `houseNumber`, `g_id`, `b_id`) VALUES (@fName,@MName,@LName,@HNum,@gender,@bgy)";
            MySqlConnection databaseConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(getMembers, databaseConn);
            command.Parameters.AddWithValue("@fName", firstName);
            command.Parameters.AddWithValue("@MName", midleName);
            command.Parameters.AddWithValue("@LName", lastName);
            command.Parameters.AddWithValue("@HNum", houseNumber);
            command.Parameters.AddWithValue("@bgy", brgy);
            command.Parameters.AddWithValue("@gender", gender);

            try
            {
                databaseConn.Open();
                MySqlDataReader read = command.ExecuteReader();
                databaseConn.Close();
                MessageBox.Show("Success");


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


    }
}