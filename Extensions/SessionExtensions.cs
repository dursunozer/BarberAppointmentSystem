using Newtonsoft.Json;

namespace BarberAppointmentSystem.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value) 
        {
            session.SetString(key, JsonConvert.SerializeObject(value));   // Hangi türde veri gelirse gelsin json formatına çevirip sessiona ekler
        }
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key); // Sessiondaki veriyi alır
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value); // Json formatındaki veriyi geriye dönüştürür
        }
    }
}
