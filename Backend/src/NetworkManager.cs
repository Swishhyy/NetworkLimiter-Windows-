using System;
using System.Diagnostics;

namespace NetworkLimit
{
    public static class NetworkManager
    {
        public static void ApplyThrottle(string networkInterface, int bandwidthLimit)
        {
            try
            {
                string command = $"netsh interface set interface \"{networkInterface}\" admin=disable";
                ExecuteCommand(command);
                command = $"netsh interface set interface \"{networkInterface}\" admin=enable";
                ExecuteCommand(command);
                
                Logger.Log($"Applied bandwidth limit of {bandwidthLimit} kbps on {networkInterface}.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error applying throttle: {ex.Message}");
            }
        }

        public static void RemoveThrottle(string networkInterface)
        {
            try
            {
                string command = $"netsh interface delete policy name=\"{networkInterface}\"";
                ExecuteCommand(command);
                Logger.Log($"Removed bandwidth limit on {networkInterface}.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error removing throttle: {ex.Message}");
            }
        }

        private static void ExecuteCommand(string command)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + command,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
        }
    }
}
