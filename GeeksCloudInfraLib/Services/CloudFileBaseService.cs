using System.Globalization;
using System.IO;
using System.Linq;
using GeeksCloudInfraLib.Interfaces;
using Newtonsoft.Json;

namespace GeeksCloudInfraLib.Services
{
    public class CloudFileBaseService : ICloudResourceService
    {
        readonly string _providerPath;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public CloudFileBaseService(string baseRoot, ICloudProvider provider)
        {
            _providerPath = CreateDirectory(provider.Name, baseRoot);

            _jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }

        public void CreateResource(IResource resource, IInfrastructure infra)
        {
            var infraPath = CreateDirectory(infra.Name, _providerPath);
            var resourcePath = CreateDirectory(resource.Name, infraPath);
            WriteJson(infra, resource);
        }

        public void DeleteInfrastructure(IInfrastructure infra)
        {
            var infraPath = Path.Combine(_providerPath, infra.Name);

            var directoryInfo = new DirectoryInfo(infraPath);

            foreach (var directory in directoryInfo.EnumerateDirectories())
            {
                var jsonFile = directory.EnumerateFiles("*.json").FirstOrDefault();
                if (jsonFile == null)
                {
                    throw new FileNotFoundException("Config file is not available!!!!");
                }
                var text = File.ReadAllText(jsonFile.FullName);
                var deserializeObject = JsonConvert.DeserializeObject(text, _jsonSerializerSettings);

                if (!(deserializeObject is IMaybeAggregated))
                {
                    jsonFile.Delete();
                    directory.Delete();
                }
            }

            var directoryInfo2 = new DirectoryInfo(infraPath);
            foreach (var directory in directoryInfo2.EnumerateDirectories())
            {
                directory.Delete(true);
            }
        }


        private void WriteJson(IInfrastructure infra, IResource resource)
        {
            var filePath = GetFileNamePath(infra.Name, resource.Name);


            var serialized = JsonConvert.SerializeObject(resource, _jsonSerializerSettings);

            File.WriteAllText(filePath, serialized);
        }

        private string GetFileNamePath(string infraName, string resourceName)
        {
            var infraUpperName = infraName.ToUpper(CultureInfo.InvariantCulture);
            var resourceUpperName = resourceName.ToUpper(CultureInfo.InvariantCulture);

            var fileNamePath = Path.Combine(_providerPath, infraName, resourceName,
                $"{infraUpperName}_{resourceUpperName}_SERVER.json");

            return fileNamePath;
        }

        private string CreateDirectory(string dirName, string parentPath)
        {
            var path = Path.Combine(parentPath, dirName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }

}