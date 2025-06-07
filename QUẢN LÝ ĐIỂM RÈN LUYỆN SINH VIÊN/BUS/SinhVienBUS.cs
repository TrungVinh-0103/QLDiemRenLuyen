using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Parser;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS
{
    public class SinhVienBUS
    {
        private SinhVienDAO svDAO = new SinhVienDAO();

        public bool InsertSinhVien(SinhVien sv)
        {
            if (string.IsNullOrWhiteSpace(sv.MaSV) || string.IsNullOrWhiteSpace(sv.HoTen))
            {
                throw new Exception("Mã SV và họ tên không được để trống.");
            }
            if (!DateUtils.IsValidDateOfBirth(sv.NgaySinh))
            {
                throw new Exception("Ngày sinh không hợp lệ.");
            }
            try
            {
                return svDAO.InsertSinhVien(sv) == 1;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }
        public DataTable GetAllSinhVien()
        {
            try
            {
                return svDAO.GetAllSinhVien();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi lấy danh sách sinh viên: " + ex.Message);
            }
        }
        //public DataTable SearchSinhVien(string maSV)
        //{
        //    return svDAO.SearchSinhVien(maSV);
        //}

        //Tìm kiếm như này nè cho nó tiện nha ní, đè Ctrl rồi click vào hàm SearchSinhVienProc để xem code của nó nha, BUS xong thì bay qua frmQuanLySinhVien.cs mà gọi svBUS từ giao diện bằng nút Tìm kiếm
        public DataTable SearchSinhVienProc(String keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new Exception("Từ khóa tìm kiếm không được để trống!");
            }
            try
            {
                return svDAO.SearchSinhVienProc(keyword);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi tìm kiếm sinh viên: " + ex.Message);
            }
        }
        public bool UpdateSinhVien(SinhVien sv, string maSV)
        {
            if (string.IsNullOrWhiteSpace(sv.MaSV) || string.IsNullOrWhiteSpace(sv.HoTen))
            {
                throw new Exception("Mã SV và họ tên không được để trống.");
            }
            if (!DateUtils.IsValidDateOfBirth(sv.NgaySinh))
            {
                throw new Exception("Ngày sinh không hợp lệ.");
            }
            try
            {
                return svDAO.UpdateSinhVien(sv) == 1;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }
        public bool DeleteSinhVien(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                throw new Exception("Mã SV không được để trống.");
            }
            try
            {
                return svDAO.DeleteSinhVien(maSV) == 1;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi xóa sinh viên: " + ex.Message);
            }
        }
        public SinhVien GetSinhVienByMaSV(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                throw new Exception("Mã SV không được để trống.");
            }
            try
            {
                // Assuming the DataTable returned by SearchSinhVien contains a single row for the given MaSV  
                DataTable dt = svDAO.SearchSinhVien(maSV);
                if (dt.Rows.Count == 0)
                {
                    return null; // No matching SinhVien found  
                }

                DataRow row = dt.Rows[0];
                return new SinhVien
                {
                    MaSV = row["MaSV"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = DateTime.Parse(row["NgaySinh"].ToString()),
                    // Map other properties of SinhVien as needed  
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi lấy thông tin sinh viên: " + ex.Message);
            }
        }

        internal DataTable SearchSinhVien(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                throw new Exception("Mã SV không được để trống.");
            }
            try
            {
                return svDAO.SearchSinhVien(maSV);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi tìm kiếm sinh viên: " + ex.Message);
            }
        }

        //CheckMaSVExists
        public bool CheckMaSVExists(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                throw new Exception("Mã SV không được để trống.");
            }
            try
            {
                return svDAO.CheckMaSVExists(maSV);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi kiểm tra mã sinh viên: " + ex.Message);
            }
        }

        public DataTable GetSinhVienByLop(string tenLop, string maKhoa, string maNienKhoa)
        {
            if (string.IsNullOrWhiteSpace(tenLop) || string.IsNullOrWhiteSpace(maKhoa) || string.IsNullOrWhiteSpace(maNienKhoa))
            {
                throw new Exception("Thông tin lớp, khoa hoặc niên khóa không được để trống.");
            }
            try
            {
                return svDAO.GetSinhVienByLop(tenLop, maKhoa, maNienKhoa);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi lấy danh sách sinh viên theo lớp: " + ex.Message);
            }
        }

        public DataTable GetSinhVienByLop(string tenLop)
        {
            if (string.IsNullOrWhiteSpace(tenLop))
            {
                throw new Exception("Tên lớp không được để trống.");
            }
            try
            {
                return svDAO.GetSinhVienByLop(tenLop);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw new Exception("Lỗi khi lấy danh sách sinh viên theo lớp: " + ex.Message);
            }
        }
    }
}

