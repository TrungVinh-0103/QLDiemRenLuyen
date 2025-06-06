using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using System.Drawing.Text;
using System.Data;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO
{
    public class SinhVienDAO
    {
        private DBConnect db = new DBConnect();


        public DataTable SearchSinhVien(string maSV)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_SearchSinhVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public int InsertSinhVien(SinhVien sv)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_InsertSinhVien", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                    cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                    cmd.Parameters.AddWithValue("@QueQuan", sv.QueQuan);
                    cmd.Parameters.AddWithValue("@TenLop", sv.TenLop);
                    cmd.Parameters.AddWithValue("@MaKhoa", sv.MaKhoa);
                    cmd.Parameters.AddWithValue("@MaNienKhoa", sv.MaNienKhoa);
                    cmd.Parameters.AddWithValue("@TrangThai", sv.TrangThai);
                    cmd.Parameters.AddWithValue("@Email", sv.Email);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        //không sử dụng procedure
        public int UpdateSinhVien(SinhVien sv)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, QueQuan = @QueQuan, TenLop = @TenLop, MaKhoa = @MaKhoa, MaNienKhoa = @MaNienKhoa, TrangThai = @TrangThai, Email = @Email WHERE MaSV = @MaSV", conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                    cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                    cmd.Parameters.AddWithValue("@QueQuan", sv.QueQuan);
                    cmd.Parameters.AddWithValue("@TenLop", sv.TenLop);
                    cmd.Parameters.AddWithValue("@MaKhoa", sv.MaKhoa);
                    cmd.Parameters.AddWithValue("@MaNienKhoa", sv.MaNienKhoa);
                    cmd.Parameters.AddWithValue("@TrangThai", sv.TrangThai);
                    cmd.Parameters.AddWithValue("@Email", sv.Email);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteSinhVien(string maSV)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_DeleteSinhVien", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    return (int)cmd.ExecuteNonQuery();
                }
            }
        }
        //không sử dụng procedure
        public DataTable GetAllSinhVien()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SinhVien", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable SearchSinhVienProc(String keyword)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_SearchSinhVienMultiField", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", keyword);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        //SearchSinhVien
        //public DataTable SearchSinhVien(string maSV)
        //{
        //    using (SqlConnection conn = db.GetConnection())
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM SinhVien WHERE MaSV LIKE @MaSV", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@MaSV", "%" + maSV + "%");
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}
        //CheckMaSVExists
        public bool CheckMaSVExists(string maSV)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV", conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static DataTable GetAllSinhVien_STT()
        {
            string query = @"
        SELECT MaSV, HoTen, NgaySinh, GioiTinh, QueQuan, TenLop, MaKhoa, MaNienKhoa, TrangThai, Email
        FROM SinhVien
        ORDER BY HoTen"; // hoặc ORDER BY MaSV
            return DataProvider.ExecuteQuery(query);
        }


    }


}
