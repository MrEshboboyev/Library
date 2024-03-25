using static Library.Web.Utility.SD;

namespace Library.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public object? Data { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
    }
}
