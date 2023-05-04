namespace WorkShopSample1.Helper
{
    public class CookieHelper : ICookieHelper
    {
        private readonly IHttpContextAccessor httpContext;

        public CookieHelper(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        public bool WriteItemToCookie(string key, string value)
        {
            try
            {
                CookieOptions opt = new CookieOptions();
                opt.Expires = DateTime.Now.AddDays(90);

                httpContext.HttpContext.Response.Cookies.Append(key, value, opt);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string ReadItemFromCookie(string key)
        {
            return httpContext.HttpContext.Request.Cookies[key] ?? "";
        }
    }
}