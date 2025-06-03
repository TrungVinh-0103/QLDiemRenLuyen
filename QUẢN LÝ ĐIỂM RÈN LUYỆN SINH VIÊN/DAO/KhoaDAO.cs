using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO
{
    public class KhoaDAO
    {
        private DBConnect db = new DBConnect();

        public DataTable GetAllKhoa()
        {
            //using (SqlConnection conn = db.GetConnection())
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = new SqlCommand("SELECT MaKhoa, TenKhoa FROM Khoa", conn))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        return dt;
            //    }
            //}
            string query = "SELECT MaKhoa, TenKhoa FROM Khoa";
            return DataProvider.ExecuteQuery(query);
        }
        // Add the missing method to resolve the error
        public DataTable GetKhoaByMaKhoa(string maKhoa)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Khoa WHERE MaKhoa = @MaKhoa", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
