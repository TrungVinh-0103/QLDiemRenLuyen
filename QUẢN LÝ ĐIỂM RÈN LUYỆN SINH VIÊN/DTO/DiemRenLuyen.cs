using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class DiemRenLuyen
    {
        public string MaSV { get; set; }
        public string MaHocKy { get; set; }
        public int Nam { get; set; }
        public decimal Diem { get; set; }
        public string XepLoai { get; set; }

        public DiemRenLuyen(string maSV, string maHocKy, int nam, decimal diem, string xepLoai)
        {
            MaSV = maSV;
            MaHocKy = maHocKy;
            Nam = nam;
            Diem = diem;
            XepLoai = xepLoai;
        }

    }
}
