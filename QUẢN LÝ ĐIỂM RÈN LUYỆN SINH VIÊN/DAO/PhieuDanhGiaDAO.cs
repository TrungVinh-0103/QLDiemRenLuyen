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

                string query = @"
            INSERT INTO PhieuDanhGia (
                MaSV, MaHocKy, Nam, LoaiPhieu,
                Diem1_1, Diem1_2, Diem1_3, Diem1_4, Diem1_5, Diem1_6, Diem1_7, Diem1_8,
                Diem2_1, Diem2_2, Diem2_3, Diem2_4, Diem2_5, Diem2_6, Diem2_7,
                Diem3_1, Diem3_2, Diem3_3, Diem3_4, Diem3_5, Diem3_6, Diem3_7,
                Diem4_1, Diem4_2, Diem4_3, Diem4_4, Diem4_5,
                Diem5_1, Diem5_2, Diem5_3, Diem5_4, Diem5_5, Diem5_6,
                TongDiem
            )
            VALUES (
                @MaSV, @MaHocKy, @Nam, @LoaiPhieu,
                @Diem1_1, @Diem1_2, @Diem1_3, @Diem1_4, @Diem1_5, @Diem1_6, @Diem1_7, @Diem1_8,
                @Diem2_1, @Diem2_2, @Diem2_3, @Diem2_4, @Diem2_5, @Diem2_6, @Diem2_7,
                @Diem3_1, @Diem3_2, @Diem3_3, @Diem3_4, @Diem3_5, @Diem3_6, @Diem3_7,
                @Diem4_1, @Diem4_2, @Diem4_3, @Diem4_4, @Diem4_5,
                @Diem5_1, @Diem5_2, @Diem5_3, @Diem5_4, @Diem5_5, @Diem5_6,
                @TongDiem
            );
            SELECT SCOPE_IDENTITY(); -- Lấy ID vừa insert
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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

                    cmd.Parameters.AddWithValue("@TongDiem", pg.TongDiem);

                    // Trả về mã phiếu vừa insert (giả sử cột MaPhieu là IDENTITY)
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        public DataTable GetPhieuDanhGia(string maSV, string maHocKy, int nam)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT * 
            FROM PhieuDanhGia
            WHERE (@MaSV IS NULL OR MaSV = @MaSV)
              AND (@MaHocKy IS NULL OR MaHocKy = @MaHocKy)
              AND (@Nam IS NULL OR Nam = @Nam)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", string.IsNullOrEmpty(maSV) ? (object)DBNull.Value : maSV);
                    cmd.Parameters.AddWithValue("@MaHocKy", string.IsNullOrEmpty(maHocKy) ? (object)DBNull.Value : maHocKy);
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

        public DataTable GetPhieuDanhGiaByMaPhieu(int maPhieu)
        {
            //không sử dụng procedure
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuDanhGia WHERE MaPhieu = @MaPhieu", conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool UpdatePhieuDanhGia(int maPhieu, int totalScore, PhieuDanhGia pg)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
            UPDATE PhieuDanhGia
            SET
                MaSV = @MaSV,
                MaHocKy = @MaHocKy,
                Nam = @Nam,
                LoaiPhieu = @LoaiPhieu,
                Diem1_1 = @Diem1_1,
                Diem1_2 = @Diem1_2,
                Diem1_3 = @Diem1_3,
                Diem1_4 = @Diem1_4,
                Diem1_5 = @Diem1_5,
                Diem1_6 = @Diem1_6,
                Diem1_7 = @Diem1_7,
                Diem1_8 = @Diem1_8,
                Diem2_1 = @Diem2_1,
                Diem2_2 = @Diem2_2,
                Diem2_3 = @Diem2_3,
                Diem2_4 = @Diem2_4,
                Diem2_5 = @Diem2_5,
                Diem2_6 = @Diem2_6,
                Diem2_7 = @Diem2_7,
                Diem3_1 = @Diem3_1,
                Diem3_2 = @Diem3_2,
                Diem3_3 = @Diem3_3,
                Diem3_4 = @Diem3_4,
                Diem3_5 = @Diem3_5,
                Diem3_6 = @Diem3_6,
                Diem3_7 = @Diem3_7,
                Diem4_1 = @Diem4_1,
                Diem4_2 = @Diem4_2,
                Diem4_3 = @Diem4_3,
                Diem4_4 = @Diem4_4,
                Diem4_5 = @Diem4_5,
                Diem5_1 = @Diem5_1,
                Diem5_2 = @Diem5_2,
                Diem5_3 = @Diem5_3,
                Diem5_4 = @Diem5_4,
                Diem5_5 = @Diem5_5,
                Diem5_6 = @Diem5_6,
                TongDiem = @TongDiem
            WHERE MaPhieu = @MaPhieu";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
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
                    cmd.Parameters.AddWithValue("@TongDiem", totalScore);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
