using System;
using System.Text.RegularExpressions;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers
{
    public class ValidationHelper
    {
        public static bool IsValidMaSV(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return false;
            // Kiểm tra định dạng mã SV (ví dụ: 6 ký tự số)
            return Regex.IsMatch(maSV, @"^\d{6}$");
        }

        public static bool IsValidScore(int score, int maxScore)
        {
            return score >= 0 && score <= maxScore;
        }

        public static bool IsValidTotalScore(int totalScore)
        {
            return totalScore >= 0 && totalScore <= 100;
        }

        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return Regex.IsMatch(name, @"^[a-zA-ZÀ-ỹ\s]+$");
        }
    }
}