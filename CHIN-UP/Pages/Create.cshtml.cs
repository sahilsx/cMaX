using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CHIN_UP.Pages
{
    public class CreateModel : PageModel

    {


        private readonly string connectionString = "Data Source=DESKTOP-8B6K3FB;Initial Catalog=SQL PRACTICE;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";



        public Memberinfo internInfo = new Memberinfo();
        public string errorMessage = "";
        public string successMessage = "";




        public void OnGet()
        {
        }

        public void OnPost()
        {
            internInfo.Member_Name = Request.Form["Member_Name"];
            internInfo.Membership= Request.Form["Membership"];
            internInfo.Membership_Duration = Request.Form["Membership_Duration"];
            

            if (internInfo.Member_Name.Length == 0 || internInfo.Membership.Length == 0 || internInfo.Membership_Duration.Length == 0)
            {
                errorMessage = "All feilds are required";
                return;
            }
            // save the new client into the database
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO members" +
                        "(Member_Name ,Membership ,Membership_Duration ) VALUES " +
                        "(@MemberName , @Membership , @MembershipDurationd  )";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@MemberName", internInfo.Member_Name);
                        command.Parameters.AddWithValue("@Membership", internInfo.Membership);
                        command.Parameters.AddWithValue("@MembershipDurationd", internInfo.Membership_Duration);
                      

                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }




            internInfo.Member_Name= " ";
            internInfo.Membership = " ";
            internInfo.Membership_Duration = " ";
           
            successMessage = "New client added suceesfully";

            Response.Redirect("/Primelist");
        }
    }
}
