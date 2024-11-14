namespace NetworkLimit.Config
{
    public class ServiceConfig
    {
        public int BandwidthLimit { get; set; } = 1000; // Default limit in kbps
        public string NetworkInterface { get; set; } = "Ethernet";
        public string StartTime { get; set; } = "08:00";
        public string EndTime { get; set; } = "17:00";
    }
}
