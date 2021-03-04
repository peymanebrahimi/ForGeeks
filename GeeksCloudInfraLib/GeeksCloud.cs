using GeeksCloudInfraLib.Interfaces;
using GeeksCloudInfraLib.Services;

namespace GeeksCloudInfraLib
{
    public class GeeksCloud
    {
        private readonly ICloudResourceService _resourceService;

        public GeeksCloud(ICloudResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public void CreateResource(IResource resource, IInfrastructure infra)
        {
            _resourceService.CreateResource(resource, infra);
        }

        public void DeleteResource(IInfrastructure infra)
        {
            _resourceService.DeleteInfrastructure(infra);
        }


    }


}
