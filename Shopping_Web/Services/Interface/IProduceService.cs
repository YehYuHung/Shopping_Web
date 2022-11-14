using Shopping_Web.Models;
using System.Text.Json;

namespace Shopping_Web.Services.Interface
{
    public interface IProduceService
    {
        /// <summary>
        /// 獲取初始化資料
        /// </summary>
        /// <returns>Produce物件</returns>
        Task<Produce> GetInitial();


        /// <summary>
        /// 採用後端 service 獲取 Get資料
        /// </summary>
        /// <returns>Get物件</returns>
        Task<MiddleResult> GetRequestData();

        /// <summary>
        /// 測試Property屬性
        /// </summary>
        /// <param name="dic">Json回傳資料</param>
        Task GetPropertyTesting<T>(Dictionary<string, JsonElement> dic);
    }
}
