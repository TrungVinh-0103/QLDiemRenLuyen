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
    public class MinhChungBUS
    {
        private MinhChungDAO mcDAO = new MinhChungDAO();

        public bool AddMinhChung(MinhChung mc)
        {
            try
            {
                return mcDAO.InsertMinhChung(mc) == 1;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }
        public DataTable GetMinhChungByPhieu(int maPhieu)
        {
            try
            {
                return mcDAO.GetMinhChungByPhieu(maPhieu);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
