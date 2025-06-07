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
    public class HocKyBUS
    {
        private HocKyDAO hocKyDAO = new HocKyDAO();

        public DataTable GetAllHocKy()
        {
            return hocKyDAO.GetAllHocKy();
        }

        public DataTable GetHocKyByNam(int nam)
        {
            if (nam <= 0)
            {
                throw new ArgumentException("Năm học không hợp lệ.");
            }
            return hocKyDAO.GetHocKyByNam(nam);
        }
    }
}
