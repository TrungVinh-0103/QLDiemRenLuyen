using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using System.Data.SqlClient;
using System.Data;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO
{
    public class MinhChungDAO
    {
        private DBConnect db = new DBConnect();

        public int InsertMinhChung(MinhChung mc)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_InsertMinhChung", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaPhieu", mc.MaPhieu);
                    cmd.Parameters.AddWithValue("@ImageData", mc.ImageData);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public DataTable GetMinhChungByPhieu(int maPhieu)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GetMinhChungByPhieu", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
