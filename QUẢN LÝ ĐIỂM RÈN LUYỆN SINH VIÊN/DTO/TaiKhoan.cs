namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class TaiKhoan
    {
        public string MaDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string LoaiTaiKhoan { get; set; }
    }

    public class TaiKhoanDTO
    {
        public string MaDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string LoaiTaiKhoan { get; set; }
        public TaiKhoanDTO(string maDangNhap, string matKhau, string loaiTaiKhoan)
        {
            MaDangNhap = maDangNhap;
            MatKhau = matKhau;
            LoaiTaiKhoan = loaiTaiKhoan;
        }
    }
}
