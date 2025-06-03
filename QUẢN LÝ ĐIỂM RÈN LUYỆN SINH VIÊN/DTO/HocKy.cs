namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class HocKy
    {
        public string MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public int Nam { get; set; }

        public HocKy(string maHocKy, string tenHocKy, int nam)
        {
            MaHocKy = maHocKy;
            TenHocKy = tenHocKy;
            Nam = nam;
        }
    }
}
