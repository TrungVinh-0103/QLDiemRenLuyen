namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class NienKhoa
    {
        public string MaNienKhoa { get; set; }
        public string TenNienKhoa { get; set; }
        public int Duration { get; set; } // Số năm (6 năm cho y khoa)
        
        //Constructor
        public NienKhoa(string maNienKhoa, string tenNienKhoa, int duration)
        {
            MaNienKhoa = maNienKhoa;
            TenNienKhoa = tenNienKhoa;
            Duration = duration;
        }
    }
}