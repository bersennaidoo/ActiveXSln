//using Newtonsoft.Json;
//using Microsoft.AspNetCore.Http;
using System.Text.Json;

//namespace ActvieX.Infrastructure;
namespace Microsoft.AspNetCore.Http;

public static class SessionExtensions
{
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);

        return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
    }
}
