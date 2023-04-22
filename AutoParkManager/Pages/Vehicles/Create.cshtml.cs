using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AutoParkManager.Pages.Vehicles
{
    public class CreateModel : PageModel
    {
        public VehInfo vehInfo = new VehInfo();
        public String errorMessage = "";
        public String succesMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            vehInfo.marca = Request.Form["marca"];
            string numeMarca = vehInfo.marca;
            vehInfo.modelv = Request.Form["modelv"];
            vehInfo.combustibil = Request.Form["combustibil"];
            vehInfo.an = Request.Form["an"];
            vehInfo.capacitate = Request.Form["capacitate"];
            vehInfo.culoare = Request.Form["culoare"];
            vehInfo.VIN = Request.Form["VIN"];

            if(vehInfo.marca.Length == 0 || vehInfo.modelv.Length == 0 || vehInfo.an.Length == 0 || vehInfo.combustibil.Length == 0 ||
                vehInfo.capacitate.Length == 0 || vehInfo.culoare.Length == 0 || vehInfo.VIN.Length == 0)
            {
                errorMessage = "Toate campurile trebuie sa detina informatie";
                return;
            }

            try
            {
                String connectionString = "Data Source=DREYZ;Initial Catalog=auotparkdb;Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO vehicleDB " +
                                 "(marca, modelv, combustibil, an, capacitate, culoare, VIN) VALUES" +
                                 "(@marca, @modelv, @combustibil, @an, @capacitate, @culoare, @VIN);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@marca", vehInfo.marca);
                        command.Parameters.AddWithValue("@modelv", vehInfo.modelv);
                        command.Parameters.AddWithValue("@combustibil", vehInfo.combustibil);
                        command.Parameters.AddWithValue("@an", vehInfo.an);
                        command.Parameters.AddWithValue("@capacitate", vehInfo.capacitate);
                        command.Parameters.AddWithValue("@culoare", vehInfo.culoare);
                        command.Parameters.AddWithValue("@VIN", vehInfo.VIN);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            vehInfo.marca = "";
            vehInfo.modelv = "";
            vehInfo.combustibil = "";
            vehInfo.an = "";
            vehInfo.capacitate = "";
            vehInfo.culoare = "";
            vehInfo.VIN = "";
            succesMessage = $"{numeMarca}-ul a fost adaugat!"; 

        }  
    }
}
