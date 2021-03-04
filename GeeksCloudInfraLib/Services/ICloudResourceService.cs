using GeeksCloudInfraLib.Interfaces;

namespace GeeksCloudInfraLib.Services
{
    public interface ICloudResourceService
    {
        void CreateResource(IResource resource, IInfrastructure infra);
        void DeleteInfrastructure(IInfrastructure infra);
    }
}