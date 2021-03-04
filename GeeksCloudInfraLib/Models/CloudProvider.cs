using System;

namespace GeeksCloudInfraLib.Models
{
    public class CloudProvider
    {
        public CloudProvider(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Name { get; }
        public string ClientName { get; set; }

    }
}
