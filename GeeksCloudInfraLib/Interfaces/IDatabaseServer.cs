namespace GeeksCloudInfraLib.Interfaces
{
    public interface IDatabaseServer : IResource
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}