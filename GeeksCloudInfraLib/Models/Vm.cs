using System;
using GeeksCloudInfraLib.Interfaces;

namespace GeeksCloudInfraLib.Models
{
    public class Vm : IVirtualMachine
    {
        public Vm(string name, VirtualHardDisk virtualHardDisk)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            VirtualHardDisk = virtualHardDisk ?? throw new ArgumentNullException(nameof(virtualHardDisk));
        }
        public string Name { get; }
        public VirtualHardDisk VirtualHardDisk { get; }
        public int Cpu { get; set; }
        public int Ram { get; set; }
        public IOperatingSystem OperatingSystem { get; set; }
    }
}