using Shopping_Web.Models;

namespace Shopping_Web.Services.Interface
{
    public interface IProduceService
    {
        /// <summary>
        /// 獲取初始化資料
        /// </summary>
        /// <returns>Produce物件</returns>
        Task<Produce> GetInitial();
    }
}
