namespace NetworkLimit.Config
{
    public class ServiceConfig
    {
        public int BandwidthLimit { get; set; } = 1000; // Default limit in kbps
        public string NetworkInterface { get; set; } = "Ethernet";
    }
}
