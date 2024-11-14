using System;
using System.ServiceProcess;
using System.Timers;

namespace NetworkLimit
{
    public class NetworkLimitService : ServiceBase
    {
        private Timer _timer;

        public NetworkLimitService()
        {
            ServiceName = "NetworkLimitService";
        }

        protected override void OnStart(string[] args)
        {
            // Set up a timer to execute periodically
            _timer = new Timer(60000); // 60 seconds
            _timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            _timer.Start();
            
            Logger.Log("Service started.");
        }

        protected override void OnStop()
        {
            _timer.Stop();
            Logger.Log("Service stopped.");
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            // Placeholder for network limiting logic
            Logger.Log("Checking network usage and applying limits as needed.");
        }

        public static void Main()
        {
            ServiceBase.Run(new NetworkLimitService());
        }
    }
}
