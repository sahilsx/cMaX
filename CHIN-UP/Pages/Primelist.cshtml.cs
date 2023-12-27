using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CHIN_UP.Pages
{
    public class Memberinfo
    {
        public string Id;
        public string Member_Name;
        public string Membership;
        public string Membership_Duration;
        public string joined_on;
        
    }
    public class PrimelistModel : PageModel

    {

        private readonly string connectionString = "Data Source=DESKTOP-8B6K3FB;Initial Catalog=SQL PRACTICE;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";





        public List<Memberinfo> members = new List<Memberinfo>();
        public void OnGet()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM members";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Memberinfo internInfo = new Memberinfo();
                                internInfo.Id = "" + reader.GetInt32(0);
                                internInfo.Member_Name = reader.GetString(1);
                                internInfo.Membership = reader.GetString(2);
                                internInfo.Membership_Duration = reader.GetString(3);
                                internInfo.joined_on = reader.GetDateTime(4).ToString();

                                members.Add(internInfo);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.ToString());
            }
        }
    }




}