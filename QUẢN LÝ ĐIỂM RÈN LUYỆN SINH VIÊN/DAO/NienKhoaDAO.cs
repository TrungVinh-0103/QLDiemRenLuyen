using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using System.Data;
using System.Data.SqlClient;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO
{
    public class NienKhoaDAO
    {
        private DBConnect db = new DBConnect();

        public DataTable GetAllNienKhoa()
        {
            string query = "SELECT MaNienKhoa, TenNienKhoa FROM NienKhoa";
            return DataProvider.ExecuteQuery(query);
        }

        // Add the missing method to resolve the error  
        public DataTable GetNienKhoaByMaKhoa(string maKhoa)
        {
            string query = "SELECT * FROM NienKhoa WHERE MaKhoa = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("@MaKhoa", maKhoa)
            };
            return DataProvider.ExecuteQuery(query, parameters);
        }
    }
}
