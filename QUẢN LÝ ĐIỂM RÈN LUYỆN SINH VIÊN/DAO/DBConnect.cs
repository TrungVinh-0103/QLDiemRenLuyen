using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO
{
    public class DBConnect
    {
        private string connectionString;

        public DBConnect()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QLRenLuyenSinhVien"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

       
    }
}
