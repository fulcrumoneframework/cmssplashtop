namespace Checkalt_Namcms_Service.Services.IServices
{
    public interface IAuthService
    {
        Task<string> GetAccesstoken();
    }
}
