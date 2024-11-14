using System;
using System.ServiceProcess;
using System.Timers;
using NetworkLimit.Config;

namespace NetworkLimit
{
    public class NetworkLimitService : ServiceBase
    {
        private Timer _timer;
        private ServiceConfig _config;

        public NetworkLimitService()
        {
            ServiceName = "NetworkLimitService";
        }

        protected override void OnStart(string[] args)
        {
            _config = ConfigLoader.LoadConfig();
            _timer = new Timer(60000); // Check every 60 seconds
            _timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            _timer.Start();
            Logger.Log("Service started with config: " + JsonSerializer.Serialize(_config));
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            DateTime now = DateTime.Now;
            DateTime start = DateTime.Parse(_config.StartTime);
            DateTime end = DateTime.Parse(_config.EndTime);

            if (now.TimeOfDay >= start.TimeOfDay && now.TimeOfDay <= end.TimeOfDay)
            {
                NetworkManager.ApplyThrottle(_config.NetworkInterface, _config.BandwidthLimit);
            }
            else
            {
                NetworkManager.RemoveThrottle(_config.NetworkInterface);
            }
        }
    }
}

