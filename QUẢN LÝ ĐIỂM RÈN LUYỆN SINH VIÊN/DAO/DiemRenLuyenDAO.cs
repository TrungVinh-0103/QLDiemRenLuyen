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
    public class DiemRenLuyenDAO
    {
        private DBConnect db = new DBConnect();

        public DataTable FilterDiemRenLuyen(string tenLop, string maKhoa, string maNienKhoa, string maHocKy, int nam)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_FilterDiemRenLuyen", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenLop", (object)tenLop ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaKhoa", (object)maKhoa ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNienKhoa", (object)maNienKhoa ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaHocKy", (object)maHocKy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nam", nam != 0 ? (object)nam : DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ThongKeChuaDat()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ThongKeChuaDat", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
