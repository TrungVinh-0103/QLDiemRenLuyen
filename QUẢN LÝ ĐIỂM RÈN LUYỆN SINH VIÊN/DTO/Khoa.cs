namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string MaTruong { get; set; }
    
    //Constructor
        public Khoa(string maKhoa, string tenKhoa, string maTruong)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
            MaTruong = maTruong;
        }
    }
}