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
    public class NienKhoaBUS
    {
        private NienKhoaDAO nienKhoaDAO = new NienKhoaDAO();

        public DataTable GetAllNienKhoa()
        {
            return nienKhoaDAO.GetAllNienKhoa();
        }

        // Add the missing method to resolve the error  
        //public DataTable GetNienKhoaByMaKhoa(string maKhoa)
        //{
        //    return nienKhoaDAO.GetNienKhoaByMaKhoa(maKhoa);
        //}
    }
}
