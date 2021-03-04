namespace GeeksCloudInfraLib.Interfaces
{
    public interface IVirtualHardDisk : IMaybeAggregated
    {
        int Size { get; set; }
    }
}