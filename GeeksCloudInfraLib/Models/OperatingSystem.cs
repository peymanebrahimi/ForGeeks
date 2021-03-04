using System;

namespace GeeksCloudInfraLib.Models
{
    public class OperatingSystem
    {

        private bool _isOn;

        public OperatingSystem(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Power()
        {
            Console.WriteLine(_isOn ? $"Shutting down the {Name} system" : $"Starting the {Name} system");
            _isOn = !_isOn;
        }

        public override string ToString()
        {
            return $"This OS is {Name}";
        }
    }
}