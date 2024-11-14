using System;
using System.ServiceProcess;
using System.Timers;
using System.IO;
using NetworkLimit.Config;
using System.Text.Json;

namespace NetworkLimit
{
    public class NetworkLimitService : ServiceBase
    {
        private Timer _timer;
        private ServiceConfig _config;
        private FileSystemWatcher _configWatcher;

        public NetworkLimitService()
        {
            ServiceName = "NetworkLimitService";
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _config = ConfigLoader.LoadConfig();
                
                _timer = new Timer(60000); // Check every 60 seconds
                _timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
                _timer.Start();
                
                Logger.Log("Service started with config: " + JsonSerializer.Serialize(_config));

                // Setup FileWatcher to detect changes in config file
                _configWatcher = new FileSystemWatcher(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config"));
                _configWatcher.Filter = "appsettings.json";
                _configWatcher.Changed += new FileSystemEventHandler(OnConfigChanged);
                _configWatcher.EnableRaisingEvents = true;

                Logger.Log("Configuration watcher started.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error starting service: {ex.Message}");
                Stop(); // Stop service if critical error occurs
            }
        }

        protected override void OnStop()
        {
            try
            {
                _timer?.Stop();
                Logger.Log("Service stopped.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error stopping service: {ex.Message}");
            }
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            if (Scheduler.IsWithinScheduledTime(_config.StartTime, _config.EndTime))
            {
                NetworkManager.ApplyThrottle(_config.NetworkInterface, _config.BandwidthLimit);
            }
            else
            {
                NetworkManager.RemoveThrottle(_config.NetworkInterface);
            }
        }

        private void OnConfigChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                Logger.Log("Configuration file changed, reloading...");
                _config = ConfigLoader.LoadConfig();
                Logger.Log("Configuration reloaded successfully.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error reloading configuration: {ex.Message}");
            }
        }

        public static void Main()
        {
            ServiceBase.Run(new NetworkLimitService());
        }
    }
}
