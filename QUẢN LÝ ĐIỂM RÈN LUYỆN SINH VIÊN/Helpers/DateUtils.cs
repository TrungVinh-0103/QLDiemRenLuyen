using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers
{
    public class DateUtils
    {
        public static bool IsValidDateOfBirth(DateTime ngaySinh)
        {
            return ngaySinh.Year >= 1900 && ngaySinh <= DateTime.Now;
        }
    }
}
