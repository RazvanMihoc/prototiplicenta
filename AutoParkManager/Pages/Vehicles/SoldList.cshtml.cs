using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AutoParkManager.Pages.Vehicles
{
    public class SoldListModel : PageModel
    {
        public List<VehInfo> carslist = new List<VehInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DREYZ;Initial Catalog=auotparkdb;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM soldVehiclesDB";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VehInfo vehInfo = new VehInfo();
                                vehInfo.id = "" + reader.GetInt32(0);
                                vehInfo.marca = reader.GetString(1);
                                vehInfo.modelv = reader.GetString(2);
                                vehInfo.combustibil = reader.GetString(3);
                                vehInfo.an = reader.GetString(4);
                                vehInfo.capacitate = reader.GetString(5);
                                vehInfo.culoare = reader.GetString(6);
                                vehInfo.VIN = reader.GetString(7);

                                carslist.Add(vehInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class VehSoldInfo
    {
        public String id;
        public String marca;
        public String combustibil;
        public String modelv;
        public String an;
        public String capacitate;
        public String culoare;
        public String VIN;
    }
}

