using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using System.Data;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS
{
    public class DiemRenLuyenBUS
    {
        private DiemRenLuyenDAO drlDAO = new DiemRenLuyenDAO();

        public DataTable FilterDiemRenLuyen(string tenLop, string maKhoa, string maNienKhoa, string maHocKy, int nam)
        {
            return drlDAO.FilterDiemRenLuyen(tenLop, maKhoa, maNienKhoa, maHocKy, nam);
        }

        public DataTable ThongKeChuaDat()
        {
            return drlDAO.ThongKeChuaDat();
        }
    }
}
