using GeeksCloudInfraLib.Interfaces;

namespace GeeksCloudInfraLib.Models
{
    public class MySqlDb : IDatabaseServer
    {
        public string Name { get; } = "MySql";
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}