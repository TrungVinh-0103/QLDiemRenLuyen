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

        public void UpdateDiemRenLuyen(string maSV, string maHocKy, int nam, int diem, string xepLoai)
        {
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maHocKy) || nam <= 0 || diem < 0 || string.IsNullOrEmpty(xepLoai))
            {
                throw new ArgumentException("Thông tin điểm rèn luyện không hợp lệ.");
            }
            try
            {
                // Không lọc điểm, lưu tất cả
                drlDAO.UpdateDiemRenLuyen(maSV, maHocKy, nam, diem, xepLoai);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật điểm rèn luyện: " + ex.Message);
            }
        }

        public DataTable GetDiemRenLuyenByMaSVAndHocKy(string maSV, string maHocKy, int nam)
        {
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(maHocKy) || nam <= 0)
            {
                throw new ArgumentException("Thông tin tìm kiếm không hợp lệ.");
            }
            try
            {
                return drlDAO.GetDiemRenLuyenByMaSVAndHocKy(maSV, maHocKy, nam);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy điểm rèn luyện: " + ex.Message);
            }
        }

        internal DataTable GetAllDiemRenLuyen()
        {
            try
            {
                return drlDAO.GetAllDiemRenLuyen();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả điểm rèn luyện: " + ex.Message);
            }
        }

        // Phương thức hiện tại ThongKeChuaDat (nếu có) có thể được thay thế
        public DataTable ThongKeChuaDat(string maHocKy, int nam)
        {
            // Logic cũ có thể được hợp nhất vào btnTaiThongKe_Click
            return drlDAO.ThongKeChuaDat(maHocKy, nam);
        }
    }
}
