using System;
using System.IO;

namespace NetworkLimit
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "service.log");

        public static void Log(string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
