using GeeksCloudInfraLib.Models;

namespace GeeksCloudInfraLib.Interfaces
{
    public interface IVirtualMachine : IResource
    {
        int Cpu { get; set; }
        int Ram { get; set; }
        IOperatingSystem OperatingSystem { get; set; }
        VirtualHardDisk VirtualHardDisk { get; }
    }
}