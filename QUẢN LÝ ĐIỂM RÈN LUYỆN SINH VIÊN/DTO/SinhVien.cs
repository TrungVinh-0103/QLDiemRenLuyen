using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class SinhVien
    {
        public int STT { get; set; }
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string TenLop { get; set; }
        public string MaKhoa { get; set; }
        public string MaNienKhoa { get; set; }
        public string TrangThai { get; set; }
        public string Email { get; set; }
        // Constructor
        public SinhVien(int stt,string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string tenLop, string maKhoa, string maNienKhoa, string trangThai, string email)
        {
            STT = stt;
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            TenLop = tenLop;
            MaKhoa = maKhoa;
            MaNienKhoa = maNienKhoa;
            TrangThai = trangThai;
            Email = email;
        }
        // Default constructor
        public SinhVien() { }

    }
}
