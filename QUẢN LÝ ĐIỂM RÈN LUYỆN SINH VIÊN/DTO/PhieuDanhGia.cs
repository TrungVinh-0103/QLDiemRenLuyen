using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class PhieuDanhGia
    {
        public long MaPhieu { get; set; }
        public string MaSV { get; set; }
        public string MaHocKy { get; set; }
        public int Nam { get; set; }
        public string LoaiPhieu { get; set; }
        public int Diem1_1 { get; set; }
        public int Diem1_2 { get; set; }
        public int Diem1_3 { get; set; }
        public int Diem1_4 { get; set; }
        public int Diem1_5 { get; set; } //làm đến Diem1_8
        public int Diem1_6 { get; set; }
        public int Diem1_7 { get; set; }
        public int Diem1_8 { get; set; }
        public int Diem2_1 { get; set; }
        public int Diem2_2 { get; set; }
        public int Diem2_3 { get; set; }
        public int Diem2_4 { get; set; }
        public int Diem2_5 { get; set; }
        public int Diem2_6 { get; set; }
        public int Diem2_7 { get; set; }
        public int Diem3_1 { get; set; }
        public int Diem3_2 { get; set; }
        public int Diem3_3 { get; set; }
        public int Diem3_4 { get; set; }
        public int Diem3_5 { get; set; }
        public int Diem3_6 { get; set; }
        public int Diem3_7 { get; set; }
        public int Diem4_1 { get; set; }
        public int Diem4_2 { get; set; }
        public int Diem4_3 { get; set; }
        public int Diem4_4 { get; set; }
        public int Diem4_5 { get; set; }
        public int Diem5_1 { get; set; }
        public int Diem5_2 { get; set; }
        public int Diem5_3 { get; set; }
        public int Diem5_4 { get; set; }
        public int Diem5_5 { get; set; }
        public int Diem5_6 { get; set; }
        public int TongDiem { get; set; }
        public byte[] ImageMinhChung { get; set; }

        // Constructor
        public PhieuDanhGia(long maPhieu, string maSV, string maHocKy, int nam, string loaiPhieu,
            int diem1_1, int diem1_2, int diem1_3, int diem1_4, int diem1_5, int diem1_6, int diem1_7, int diem1_8,
            int diem2_1, int diem2_2, int diem2_3, int diem2_4, int diem2_5, int diem2_6, int diem2_7,
            int diem3_1, int diem3_2, int diem3_3, int diem3_4, int diem3_5, int diem3_6, int diem3_7,
            int diem4_1, int diem4_2, int diem4_3, int diem4_4, int diem4_5,
            int diem5_1, int diem5_2, int diem5_3, int diem5_4, int diem5_5, int diem5_6,
            byte[] imageMinhChung)
        {
            MaPhieu = maPhieu;
            MaSV = maSV;
            MaHocKy = maHocKy;
            Nam = nam;
            LoaiPhieu = loaiPhieu;
            Diem1_1 = diem1_1;
            Diem1_2 = diem1_2;
            Diem1_3 = diem1_3;
            Diem1_4 = diem1_4;
            Diem1_5 = diem1_5;
            Diem1_6 = diem1_6;
            Diem1_7 = diem1_7;
            Diem1_8 = diem1_8;
            Diem2_1 = diem2_1;
            Diem2_2 = diem2_2;
            Diem2_3 = diem2_3;
            Diem2_4 = diem2_4;
            Diem2_5 = diem2_5;
            Diem2_6 = diem2_6;
            Diem2_7 = diem2_7;
            Diem3_1 = diem3_1;
            Diem3_2 = diem3_2;
            Diem3_3 = diem3_3;
            Diem3_4 = diem3_4;
            Diem3_5 = diem3_5;
            Diem3_6 = diem3_6;
            Diem3_7 = diem3_7;
            Diem4_1 = diem4_1;
            Diem4_2 = diem4_2;
            Diem4_3 = diem4_3;
            Diem4_4 = diem4_4;
            Diem4_5 = diem4_5;
            Diem5_1 = diem5_1;
            Diem5_2 = diem5_2;
            Diem5_3 = diem5_3;
            Diem5_4 = diem5_4;
            Diem5_5 = diem5_5;
            Diem5_6 = diem5_6;
            ImageMinhChung = imageMinhChung;
            TongDiem = Diem1_1 + Diem1_2 + Diem1_3 + Diem1_4 + Diem1_5 + Diem1_6 + Diem1_7 + Diem1_8 +
                       Diem2_1 + Diem2_2 + Diem2_3 + Diem2_4 + Diem2_5 + Diem2_6 + Diem2_7 +
                       Diem3_1 + Diem3_2 + Diem3_3 + Diem3_4 + Diem3_5 + Diem3_6 + Diem3_7 +
                       Diem4_1 + Diem4_2 + Diem4_3 + Diem4_4 + Diem4_5 +
                       Diem5_1 + Diem5_2 + Diem5_3 + Diem5_4 + Diem5_5 + Diem5_6;       
        }
    }   
}
