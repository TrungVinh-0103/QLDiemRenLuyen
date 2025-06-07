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

        public int AddMinhChung(MinhChung mc)
        {
            try
            {
                int maMinhChung = mcDAO.InsertMinhChung(mc);
                if (maMinhChung <= 0)
                {
                    throw new Exception("Không thể thêm minh chứng, có thể do lỗi dữ liệu hoặc kết nối CSDL!");
                }
                return maMinhChung; // Trả về MaMinhChung vừa được tạo
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw; // Ném lại ngoại lệ với thông tin chi tiết
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
