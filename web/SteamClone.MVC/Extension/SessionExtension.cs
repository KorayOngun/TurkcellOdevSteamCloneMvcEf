using System.Text.Json;

namespace SteamClone.MVC.Extension
{
    public static class SessionExtension
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            var data = JsonSerializer.Serialize<T>(value);
            session.SetString(key, data);
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default(T) : JsonSerializer.Deserialize<T>(data);
        }
        public static object GetJson(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default : data;
        }
    }
}
