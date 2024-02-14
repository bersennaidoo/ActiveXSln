//using Newtonsoft.Json;
using System.Text.Json;

//namespace ActvieX.Infrastructure;
namespace Microsoft.AspNetCore.Http;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);

        return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
    }
}
