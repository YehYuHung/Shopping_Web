using Shopping_Web.Services.Interface;

namespace Shopping_Web.Services
{
    public class ConvertAPIService : IConvertAPIService
    {
        /// <summary>
        /// 測試Property屬性
        /// </summary>
        /// <param name="dic">Json回傳資料</param>
        public async Task GetTypeProperty<T>() => await Task.Run(() =>
        {
            var Tofproperties = typeof(T).GetProperties();

            var properties = Tofproperties.Select(x => new KeyValuePair<string, string>(x.Name.ToLowerInvariant(), x.Name))
                                          .ToDictionary(x => x.Key, x => x.Value);

            var keyStr = properties.Select(x => x.Key).Aggregate((x, y) => string.Format("{0}, {1}", x, y));
            var valueStr = properties.Select(x => x.Value).Aggregate((x, y) => string.Format("{0}, {1}", x, y));
            System.Diagnostics.Debug.WriteLine("valueStr : " + valueStr);
            System.Diagnostics.Debug.WriteLine("keyStr : " + keyStr);
        });
    }
}
