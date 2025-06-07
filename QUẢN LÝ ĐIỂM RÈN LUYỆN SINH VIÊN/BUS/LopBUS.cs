using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;
using System.Data;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS
{
    public class LopBUS
    {
        private LopDAO lopDAO;

        public LopBUS()
        {
            lopDAO = new LopDAO();
        }

        public bool AddLop(Lop lop)
        {
            // Fix: Convert the integer result of InsertLop to a boolean      
            return lopDAO.InsertLop(lop) > 0;
        }
        //tìm kiếm lớp theo tên lớp, mã khoa, mã niên khóa
        public DataTable SearchLop(string keyword)
        {
            return lopDAO.SearchLop(keyword);
        }

        //public DataTable SearchLop(string tenLop)
        //{
        //    return lopDAO.SearchLop(tenLop);

        //}

        //public DataTable GetLopByMaNienKhoa(string maNienKhoa)
        //{
        //    // Fix: Replace the incorrect method call with the correct one  
        //    return lopDAO.SearchLop(maNienKhoa);
        //}

        public void UpdateLop(string tenLop, string newTenLop, string newMaKhoa, string newMaNienKhoa)
        {
            //tạo code cập nhật lớp
            Lop lop = new Lop(newTenLop, newMaKhoa, newMaNienKhoa);
            if (lopDAO.UpdateLop(tenLop, lop) <= 0)
            {
                throw new Exception("Cập nhật lớp không thành công.");
            }
            // Thực hiện cập nhật thông tin lớp vào cơ sở dữ liệu
            // Giả sử bạn có một phương thức cập nhật lớp trong lớp DAO
            // lopDAO.UpdateLop(tenLop, newTenLop, newMaKhoa, newMaNienKhoa);
            // Nếu cập nhật thành công, không cần trả về giá trị gì
        }
        public bool DeleteLop(string tenLop, string maKhoa, string maNienKhoa)
        {
            //code thực hiện xóa lớp
            Lop lop = new Lop(tenLop, maKhoa, maNienKhoa);
            if (lopDAO.DeleteLop(tenLop) <= 0)
            {
                throw new Exception("Xóa lớp không thành công.");
            }
            return true; // Trả về true nếu xóa thành công
        }
        public DataTable GetAllLop()
        {
            //code lấy tất cả lớp
            return lopDAO.GetAllLop();
        }

        public DataTable GetAllKhoa()
        {
            //code lấy tất cả khoa
            return lopDAO.GetAllKhoa();
        }

        public DataTable GetAllNienKhoa()
        {
            //code lấy tất cả niên khóa
            return lopDAO.GetAllNienKhoa();
        }

        public string GetMaNienKhoaByTenLopAndMaKhoa(string tenLop, string maKhoa)
        {
            //code lấy mã niên khóa theo tên lớp và mã khoa
            return lopDAO.GetMaNienKhoaByTenLopAndMaKhoa(tenLop, maKhoa);
        }

        public DataTable GetLopByKhoaAndHocKy(string maKhoa, string maHocKy, int nam)
        {
            //code lấy lớp theo mã khoa, mã học kỳ và năm
            return lopDAO.GetLopByKhoaAndHocKy(maKhoa, maHocKy, nam);
        }
    }
}
