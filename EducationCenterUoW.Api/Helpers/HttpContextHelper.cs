using Microsoft.AspNetCore.Http;

namespace EducationCenterUoW.Api.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor;
        public static HttpContext Context => Accessor?.HttpContext;
        public static IHeaderDictionary ReponseHeaders => Context.Response.Headers;
    }
}
