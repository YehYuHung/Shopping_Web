namespace Shopping_Web.Services.Interface
{
    public interface IConvertAPIService
    {
        /// <summary>
        /// 測試Property屬性
        /// </summary>
        /// <param name="dic">Json回傳資料</param>
        Task GetTypeProperty<T>();
    }
}
