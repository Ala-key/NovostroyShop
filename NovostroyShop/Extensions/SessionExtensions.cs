using Newtonsoft.Json;

namespace NovostroyShop.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default(T);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<T>(value);
                return result;
            }
            
            //return value == null ? default(T) : result;
        }
    }

}
