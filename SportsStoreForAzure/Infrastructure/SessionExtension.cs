using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SportsStoreForAzure.Infrastructure
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session,
            string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetJson<T>(this ISession session,
            string key)
        {
            string sessiondata = session.GetString(key);
            return sessiondata == null ?
                default :
                JsonConvert.DeserializeObject<T>(sessiondata);
        }
    }
}
