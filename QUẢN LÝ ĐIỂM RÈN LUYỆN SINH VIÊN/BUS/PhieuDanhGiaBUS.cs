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
    public class PhieuDanhGiaBUS
    {
        private PhieuDanhGiaDAO pgDAO = new PhieuDanhGiaDAO();

        public int AddPhieuDanhGia(PhieuDanhGia pg)
        {
            if (!ValidationHelper.IsValidMaSV(pg.MaSV))
            {
                throw new Exception("Mã SV không hợp lệ.");
            }
            int totalScore = pg.Diem1_1 + pg.Diem1_2 + pg.Diem1_3 + pg.Diem1_4 + pg.Diem1_5 + pg.Diem1_6 +
                            pg.Diem1_7 + pg.Diem1_8 + pg.Diem2_1 + pg.Diem2_2 + pg.Diem2_3 + pg.Diem2_4 +
                            pg.Diem2_5 + pg.Diem2_6 + pg.Diem2_7 + pg.Diem3_1 + pg.Diem3_2 + pg.Diem3_3 +
                            pg.Diem3_4 + pg.Diem3_5 + pg.Diem3_6 + pg.Diem3_7 + pg.Diem4_1 + pg.Diem4_2 +
                            pg.Diem4_3 + pg.Diem4_4 + pg.Diem4_5 + pg.Diem5_1 + pg.Diem5_2 + pg.Diem5_3 +
                            pg.Diem5_4 + pg.Diem5_5 + pg.Diem5_6;
            if (!ValidationHelper.IsValidTotalScore(totalScore))
            {
                throw new Exception("Tổng điểm không được vượt quá 100.");
            }
            try
            {
                pg.TongDiem = totalScore;
                return pgDAO.InsertPhieuDanhGia(pg);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public DataTable GetPhieuDanhGia(string maSV, string maHocKy, int nam)
        {
            return pgDAO.GetPhieuDanhGia(maSV, maHocKy, nam);
        }

        internal void AddMinhChung(MinhChung mc)
        {
            if (mc == null || mc.ImageData == null || mc.ImageData.Length == 0)
            {
                throw new Exception("Minh chứng không hợp lệ.");
            }
            try
            {
                pgDAO.InsertMinhChung(mc);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
