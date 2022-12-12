namespace EdFi.SecurityCompatiblity53.DataAccess.Caching
{
    public interface IInstanceSecurityRepositoryCache
    {
        InstanceSecurityRepositoryCacheObject GetSecurityRepository(string instanceId);
    }
}