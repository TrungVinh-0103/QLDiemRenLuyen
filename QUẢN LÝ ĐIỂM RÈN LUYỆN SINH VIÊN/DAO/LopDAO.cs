using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using System.Data;
using System.Data.SqlClient;
using static Raven.Abstractions.Data.Constants;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO
{
    public class LopDAO
    {
        private DBConnect db = new DBConnect();

        //full code tìm lớp theo tên lớp, mã khoa, mã niên khóa, không dùng procedure
        public LopDAO() { }
        public DataTable SearchLop(string keyword)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM Lop 
                         WHERE TenLop LIKE @Keyword 
                            OR MaKhoa LIKE @Keyword 
                            OR MaNienKhoa LIKE @Keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllKhoa()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Khoa", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllNienKhoa()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM NienKhoa", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        //public DataTable SearchLop(string tenLop)
        //{
        //    using (SqlConnection conn = db.GetConnection())
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("sp_SearchLop", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@TenLop", tenLop);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}

        public int InsertLop(Lop lop)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_InsertLop", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenLop", lop.TenLop);
                    cmd.Parameters.AddWithValue("@MaKhoa", lop.MaKhoa);
                    cmd.Parameters.AddWithValue("@MaNienKhoa", lop.MaNienKhoa);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public int DeleteLop(string tenLop)
        {
            //code xóa tên lớp, xóa mã khoa, xóa mã niên khóa
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Lop WHERE TenLop = @TenLop", conn))
                {
                    cmd.Parameters.AddWithValue("@TenLop", tenLop);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int UpdateLop(string tenLop, Lop lop)
        {
            //khng sử dụng procedure
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Lop SET TenLop = @NewTenLop, MaKhoa = @NewMaKhoa, MaNienKhoa = @NewMaNienKhoa WHERE TenLop = @TenLop", conn))
                {
                    cmd.Parameters.AddWithValue("@NewTenLop", lop.TenLop);
                    cmd.Parameters.AddWithValue("@NewMaKhoa", lop.MaKhoa);
                    cmd.Parameters.AddWithValue("@NewMaNienKhoa", lop.MaNienKhoa);
                    cmd.Parameters.AddWithValue("@TenLop", tenLop);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        // Lấy danh sách lớp theo mã niên khóa
        public DataTable GetLopByMaNienKhoa(string maNienKhoa)
        {
            //không sử dụng procedure
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Lop WHERE MaNienKhoa = @MaNienKhoa", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNienKhoa", maNienKhoa);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        // Lấy danh sách lớp theo mã khoa
        public DataTable GetLopByMaKhoa(string maKhoa)
        {
            // không sử dụng procedure
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Lop WHERE MaKhoa = @MaKhoa", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        // Lấy danh sách lớp theo tên lớp
        public DataTable GetLopByTenLop(string tenLop)
        {
            // không sử dụng procedure
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Lop WHERE TenLop = @TenLop", conn))
                {
                    cmd.Parameters.AddWithValue("@TenLop", tenLop);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        // Lấy danh sách tất cả các lớp
        public DataTable GetAllLop()
        {
            // không sử dụng procedure
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Lop", conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public string GetMaNienKhoaByTenLopAndMaKhoa(string tenLop, string maKhoa)
        {
            string query = "SELECT MaNienKhoa FROM Lop WHERE TenLop = @TenLop AND MaKhoa = @MaKhoa";
            SqlParameter[] parameters = {
            new SqlParameter("@TenLop", tenLop),
            new SqlParameter("@MaKhoa", maKhoa)
        };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["MaNienKhoa"].ToString();
            }
            return null;
        }

        public DataTable GetLopByKhoaAndHocKy(string maKhoa, string maHocKy, int nam)
        {
            string query = @"
            SELECT DISTINCT L.TenLop, L.MaKhoa, L.MaNienKhoa
            FROM Lop L
            JOIN SinhVien SV ON L.TenLop = SV.TenLop AND L.MaKhoa = SV.MaKhoa AND L.MaNienKhoa = SV.MaNienKhoa
            JOIN PhieuDanhGia PD ON SV.MaSV = PD.MaSV
            WHERE L.MaKhoa = @MaKhoa 
            AND PD.MaHocKy = @MaHocKy 
            AND PD.Nam = @Nam";
            SqlParameter[] parameters = {
            new SqlParameter("@MaKhoa", maKhoa),
            new SqlParameter("@MaHocKy", maHocKy),
            new SqlParameter("@Nam", nam)
        };
            return DataProvider.ExecuteQuery(query, parameters);
        }
    }
}
