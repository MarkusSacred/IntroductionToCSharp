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





        public void upMembers(int id, string firstName, string midleName, string lastName, string houseNumber, int gender, int brgy)

        {

            try
            {

                string query = "UPDATE `tbl_members` SET `firstName`=@fn,`middleName`=@mn,`lastName`=@ls,`houseNumber`=@hn,`g_id`=@gender,`b_id`=@bgy WHERE id = @id";
                MySqlConnection databaseConnection = new MySqlConnection(conn);
                MySqlCommand MySqlCommand = new MySqlCommand(query, databaseConnection);
                MySqlCommand.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                MySqlCommand.Parameters.AddWithValue("@fn", firstName);
                MySqlCommand.Parameters.AddWithValue("@mn", midleName);
                MySqlCommand.Parameters.AddWithValue("@ls", lastName);
                MySqlCommand.Parameters.AddWithValue("@hn", houseNumber);
                MySqlCommand.Parameters.AddWithValue("@gender", gender);
                MySqlCommand.Parameters.AddWithValue("@bgy", brgy);

                MySqlDataReader reader;

                databaseConnection.Open();
                reader = MySqlCommand.ExecuteReader();
                MessageBox.Show("Updated Successfully");
                databaseConnection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }





        }



    }
}
