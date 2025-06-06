namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers
{
    public class EmailHelper
    {
        public EmailHelper() { }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static string SanitizeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return string.Empty;
            // Chuyển về chữ thường và loại bỏ khoảng trắng
            return email.Trim().ToLower();
        }
    }
}