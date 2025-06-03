using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO
{
    public class Lop
    {
        public string TenLop { get; set; }
        public string MaKhoa { get; set; }
        public string MaNienKhoa { get; set; }
    
    //Constructor mặc định
        //public Lop() 
        //{
        //        TenLop = string.Empty;
        //        MaKhoa = string.Empty;
        //        MaNienKhoa = string.Empty;
        //}
        //Constructor có tham số
        public Lop(string tenLop, string maKhoa, string maNienKhoa)
        {
            TenLop = tenLop;
            MaKhoa = maKhoa;
            MaNienKhoa = maNienKhoa;
        }


    }
}
