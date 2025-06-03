using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PROJ46_QLRenLuyenSinhVien.Helpers
{
    public class ImageHelper
    {
        public static byte[] ConvertImageToBytes(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File ảnh không tồn tại.");
            return File.ReadAllBytes(filePath);
        }

        public static bool IsValidImage(string filePath)
        {
            string[] validExtensions = { ".jpg", ".png" };
            return validExtensions.Contains(Path.GetExtension(filePath).ToLower());
        }
    }
}
