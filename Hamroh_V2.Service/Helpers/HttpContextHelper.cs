using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor = null!;
        public static HttpResponse Response => Accessor.HttpContext.Response;
        public static HttpRequest Request => Accessor.HttpContext.Request;
        public static IHeaderDictionary ResponseHeaders => Response.Headers;
        public static IHeaderDictionary RequestHeaders => Request.Headers;

        //public static int UserId => int.Parse(Accessor.HttpContext.User.FindFirst("Id")?.Value ?? "0");
    }
}
