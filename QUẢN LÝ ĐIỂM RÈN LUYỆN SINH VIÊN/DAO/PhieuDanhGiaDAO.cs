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
    public class PhieuDanhGiaDAO
    {
        private DBConnect db = new DBConnect();

        public int InsertPhieuDanhGia(PhieuDanhGia pg)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_InsertPhieuDanhGia", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSV", pg.MaSV);
                    cmd.Parameters.AddWithValue("@MaHocKy", pg.MaHocKy);
                    cmd.Parameters.AddWithValue("@Nam", pg.Nam);
                    cmd.Parameters.AddWithValue("@LoaiPhieu", pg.LoaiPhieu);
                    cmd.Parameters.AddWithValue("@Diem1_1", pg.Diem1_1);
                    cmd.Parameters.AddWithValue("@Diem1_2", pg.Diem1_2);
                    cmd.Parameters.AddWithValue("@Diem1_3", pg.Diem1_3);
                    cmd.Parameters.AddWithValue("@Diem1_4", pg.Diem1_4);
                    cmd.Parameters.AddWithValue("@Diem1_5", pg.Diem1_5);
                    cmd.Parameters.AddWithValue("@Diem1_6", pg.Diem1_6);
                    cmd.Parameters.AddWithValue("@Diem1_7", pg.Diem1_7);
                    cmd.Parameters.AddWithValue("@Diem1_8", pg.Diem1_8);
                    cmd.Parameters.AddWithValue("@Diem2_1", pg.Diem2_1);
                    cmd.Parameters.AddWithValue("@Diem2_2", pg.Diem2_2);
                    cmd.Parameters.AddWithValue("@Diem2_3", pg.Diem2_3);
                    cmd.Parameters.AddWithValue("@Diem2_4", pg.Diem2_4);
                    cmd.Parameters.AddWithValue("@Diem2_5", pg.Diem2_5);
                    cmd.Parameters.AddWithValue("@Diem2_6", pg.Diem2_6);
                    cmd.Parameters.AddWithValue("@Diem2_7", pg.Diem2_7);
                    cmd.Parameters.AddWithValue("@Diem3_1", pg.Diem3_1);
                    cmd.Parameters.AddWithValue("@Diem3_2", pg.Diem3_2);
                    cmd.Parameters.AddWithValue("@Diem3_3", pg.Diem3_3);
                    cmd.Parameters.AddWithValue("@Diem3_4", pg.Diem3_4);
                    cmd.Parameters.AddWithValue("@Diem3_5", pg.Diem3_5);
                    cmd.Parameters.AddWithValue("@Diem3_6", pg.Diem3_6);
                    cmd.Parameters.AddWithValue("@Diem3_7", pg.Diem3_7);
                    cmd.Parameters.AddWithValue("@Diem4_1", pg.Diem4_1);
                    cmd.Parameters.AddWithValue("@Diem4_2", pg.Diem4_2);
                    cmd.Parameters.AddWithValue("@Diem4_3", pg.Diem4_3);
                    cmd.Parameters.AddWithValue("@Diem4_4", pg.Diem4_4);
                    cmd.Parameters.AddWithValue("@Diem4_5", pg.Diem4_5);
                    cmd.Parameters.AddWithValue("@Diem5_1", pg.Diem5_1);
                    cmd.Parameters.AddWithValue("@Diem5_2", pg.Diem5_2);
                    cmd.Parameters.AddWithValue("@Diem5_3", pg.Diem5_3);
                    cmd.Parameters.AddWithValue("@Diem5_4", pg.Diem5_4);
                    cmd.Parameters.AddWithValue("@Diem5_5", pg.Diem5_5);
                    cmd.Parameters.AddWithValue("@Diem5_6", pg.Diem5_6);
                    //cmd.Parameters.AddWithValue("@ImageMinhChung", (object)pg.ImageMinhChung ?? DBNull.Value);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public DataTable GetPhieuDanhGia(string maSV, string maHocKy, int nam)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GetPhieuDanhGia", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSV", (object)maSV ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaHocKy", (object)maHocKy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nam", nam != 0 ? (object)nam : DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        internal void InsertMinhChung(MinhChung mc)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_InsertMinhChung", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaPhieu", mc.MaPhieu);
                    cmd.Parameters.AddWithValue("@ImageData", mc.ImageData);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
