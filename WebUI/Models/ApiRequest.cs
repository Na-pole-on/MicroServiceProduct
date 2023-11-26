using System.Security.AccessControl;
using static WebUI.SD;

namespace WebUI.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public Object Data { get; set; }
    }
}
