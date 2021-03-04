using GeeksCloudInfraLib.Interfaces;

namespace GeeksCloudInfraLib.IGS
{
    public class IgsCloudProvider : ICloudProvider
    {
        public string Name { get; set; } = "IGS";
        public string ClientName { get; set; }
    }
}