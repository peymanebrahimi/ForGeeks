using System;
using System.IO;
using System.Reflection;
using GeeksCloudInfraLib;
using GeeksCloudInfraLib.IGS;
using GeeksCloudInfraLib.Models;
using GeeksCloudInfraLib.Services;

namespace ConsumerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GeeksCloud geeksCloud = new GeeksCloud(new CloudFileBaseService(mainDir, new IgsCloudProvider()));

            //CreateProvider(geeksCloud);
            geeksCloud.DeleteResource(new UatInfrastructure());

            Console.WriteLine("Task done");
            Console.ReadLine();
        }

        private static void CreateProvider(GeeksCloud geeksCloud)
        {
            var virtualHardDisk = new VirtualHardDisk();
            var vm = new Vm("VirtualMachine", virtualHardDisk);
            var uatInfrastructure = new UatInfrastructure();

            geeksCloud.CreateResource(vm, uatInfrastructure);
        }
    }
}
