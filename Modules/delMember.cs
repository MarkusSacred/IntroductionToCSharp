using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntroductionToCSharp.Modules
{
    public class delMember
    {
        const string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_revsystem;";





        public void delMembers(int id)

        {

            try
            {

                string query = "UPDATE `tbl_members` SET `isDelete`= 1 WHERE id = @id";
                MySqlConnection databaseConnection = new MySqlConnection(conn);
                MySqlCommand MySqlCommand = new MySqlCommand(query, databaseConnection);
                MySqlCommand.Parameters.AddWithValue("@id", Convert.ToString(id));
   

                MySqlDataReader reader;

                databaseConnection.Open();
                reader = MySqlCommand.ExecuteReader();
                MessageBox.Show("Deleted Successfully");
                databaseConnection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }





        }



    }
}
