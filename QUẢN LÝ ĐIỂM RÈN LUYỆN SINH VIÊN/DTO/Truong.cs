namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class Truong
    {
        public string MaTruong { get; set; }
        public string TenTruong { get; set; }
    
    //Constructor
        public Truong(string maTruong, string tenTruong)
        {
            MaTruong = maTruong;
            TenTruong = tenTruong;
        }
    }
}