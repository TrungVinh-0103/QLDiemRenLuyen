using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO tkDAO = new TaiKhoanDAO();

        public DataTable AuthenticateUser(string maDangNhap, string matKhau)
        {
            //if (!ValidationHelper.IsValidMaSV(maDangNhap))
            //{
            //    throw new Exception("Mã đăng nhập không hợp lệ.");
            //}
            if (!ValidationHelper.IsValidMaSV(maDangNhap) && maDangNhap != "admin")
            {
                throw new Exception("Mã đăng nhập không hợp lệ.");
            }
            try
            {
                DataTable dt = tkDAO.AuthenticateUser(maDangNhap, matKhau);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Sai mã đăng nhập hoặc mật khẩu.");
                }
                return dt;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
