using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using BCrypt.Net;

namespace CHIN_UP.Pages
{
    public class RegisterModel : PageModel
    {


      private readonly  string connectionString = "Data Source=DESKTOP-8B6K3FB;Initial Catalog=SQL PRACTICE;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";



        public Registerinfo registerInfo = new();


        public string erormessage = "";
        public string successmessage = "";


        public void OnPost()
        {
            registerInfo.Username = Request.Form["Username"];
            registerInfo.Email = Request.Form["Email"];
            registerInfo.Password = Request.Form["Password"];

            if (registerInfo.Username.Length == 0 || registerInfo.Email.Length == 0 || registerInfo.Password.Length == 0)
            {
                erormessage = "All feilds are required";
                return;
            }



            try
            {

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerInfo.Password);


                //creating a  sql connection by paasing the connection string 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();    // opening a connection 

                    String sql = "INSERT INTO Users" +
                        "(Username, Email, Password) VALUES " +
                        "(@Username,  @Email, @Password)";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // passing the data from userinfo into sql query

                        command.Parameters.AddWithValue("@Username", registerInfo.Username);
                        command.Parameters.AddWithValue("@Email", registerInfo.Email);
                        command.Parameters.AddWithValue("@Password", hashedPassword);



                        // execute the sql query 
                        command.ExecuteNonQuery();

                        successmessage = "Registered";
                    }

                }
            }
            catch (Exception ex)
            {
                erormessage = $"an error occured:{ex.Message}";
                Console.WriteLine(ex.ToString());

            }

            registerInfo.Username = "";
            registerInfo.Email = "";
            registerInfo.Password = "";
           // Response.Redirect("/login");

        }
    }
}
