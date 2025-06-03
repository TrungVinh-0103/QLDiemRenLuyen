using System;
using System.IO;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers
{
    public class Logger
    {
        private static readonly string logPath = "log.txt";

        public static void LogError(string message)
        {
            File.AppendAllText(logPath, $"{DateTime.Now}: {message}\n");
        }
    }
}