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

        public DataTable ThongKeChuaDat(string maHocKy)
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

        public void UpdateDiemRenLuyen(string maSV, string maHocKy, int nam, int diem, string xepLoai)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("IF EXISTS (SELECT * FROM DiemRenLuyen WHERE MaSV = @MaSV AND MaHocKy = @MaHocKy AND Nam = @Nam) " +
                                                      "BEGIN UPDATE DiemRenLuyen SET Diem = @Diem, XepLoai = @XepLoai WHERE MaSV = @MaSV AND MaHocKy = @MaHocKy AND Nam = @Nam END " +
                                                      "ELSE BEGIN INSERT INTO DiemRenLuyen (MaSV, MaHocKy, Nam, Diem, XepLoai) VALUES (@MaSV, @MaHocKy, @Nam, @Diem, @XepLoai) END", conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaHocKy", maHocKy);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.Parameters.AddWithValue("@Diem", diem);
                    cmd.Parameters.AddWithValue("@XepLoai", xepLoai);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDiemRenLuyenByMaSVAndHocKy(string maSV, string maHocKy, int nam)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DiemRenLuyen WHERE MaSV = @MaSV AND MaHocKy = @MaHocKy AND Nam = @Nam", conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.Parameters.AddWithValue("@MaHocKy", maHocKy);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        internal DataTable GetAllDiemRenLuyen()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DiemRenLuyen", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        internal DataTable ThongKeChuaDat()
        {
            // không sử dụng procedure
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DiemRenLuyen WHERE Diem < 50", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        internal DataTable ThongKeChuaDat(string maHocKy, int nam)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DiemRenLuyen WHERE MaHocKy = @MaHocKy AND Nam = @Nam AND Diem < 50", conn))
                {
                    cmd.Parameters.AddWithValue("@MaHocKy", maHocKy);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
