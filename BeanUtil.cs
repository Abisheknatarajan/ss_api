
using System.Text.Json;

namespace Utils
#nullable disable
{
    public static class BeanUtil
    {
        public static R Copy<T, R>(T o)
        {
            var json = JsonSerializer.Serialize(o);
            return JsonSerializer.Deserialize<R>(json);
        }

        internal static T2 Copy<T1, T2>(string nurseDto)
        {
            throw new NotImplementedException();
        }
    }
}
