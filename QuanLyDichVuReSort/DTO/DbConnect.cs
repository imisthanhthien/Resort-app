using System.Configuration;
using System.Data.SqlClient;

namespace DTO
{
    public class DbConnect
    {
        // Kết nối database
        static string connstr = ConfigurationManager.ConnectionStrings["QuanLyDichVuReSort"].ToString();
        protected SqlConnection _conn = new SqlConnection(connstr);
    }
}
