namespace WorkShopSample1.Helper
{
    public interface ICookieHelper
    {
        bool WriteItemToCookie(string key, string value);
        string ReadItemFromCookie(string key);
    }
}