using Checkalt_Namcms_Service.Models;
using Checkalt_Namcms_Service.Services.IServices;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Checkalt_Namcms_Service.Services
{
    public class AuthService : IAuthService
    {
        public readonly IOptions<Configsettings> _Configsettings;
        public AuthService(IOptions<Configsettings> Configsettings)
        {
            _Configsettings = Configsettings;
        }


        public async Task<string> GetAccesstoken()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://custsimulator1.myclearingworks.com/Clearingworks/cxf/public/jwtauth/authenticate");
                request.Headers.Add("Cookie", "AWSALBAPP-0=AAAAAAAAAABH90K/M4teBfNdV007LgBFlx5PGAyfnX24dbN7LyVZT44EEF3Q/kFttPh4VbNrSbjhpyErYj/VH3ikNlC6aUZsn/cYCCDNOYqMwdZCoqFYXGxEt6Jq/jy4qJV+4D7iT4K2+yk=; AWSALBAPP-1=_remove_; AWSALBAPP-2=_remove_; AWSALBAPP-3=_remove_");
                var collection = new List<KeyValuePair<string, string>>();
                collection.Add(new("userId", "chetan.kerhalkar@fulcrumdigital.com"));
                collection.Add(new("password", "Demo@NAM1234"));
                var content = new FormUrlEncodedContent(collection);
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
