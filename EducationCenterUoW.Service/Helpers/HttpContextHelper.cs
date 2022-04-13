using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace EducationCenterUoW.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor;
        public static HttpContext Context => Accessor?.HttpContext;
        public static IHeaderDictionary ResponseHeaders => Context?.Response?.Headers;
        public static string Language => Context?.Request?.Headers["Accept-Language"].ToString();

        /// <summary>
        /// Basic authentication
        /// </summary>
        private static string BasicAuth => Context?.Request?.Headers["Authorization"].ToString();
        public static string BasicUsername => GetBasicCredentials().username;
        public static string BasicPassword => GetBasicCredentials().password;

        private static (string username, string password) GetBasicCredentials()
        {
            string[] basic = BasicAuth.Split(' ');
            if(basic.Length != 2)
               return (string.Empty, string.Empty);

            byte[] data = Convert.FromBase64String(basic[1]);
            string decodedString = Encoding.UTF8.GetString(data);

            return (decodedString.Split(':')[0], decodedString.Split(':')[1]);
        }
    }
}
