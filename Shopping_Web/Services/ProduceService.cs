using Shopping_Web.Models;
using Shopping_Web.Services.Interface;

namespace Shopping_Web.Services
{
    public class ProduceService : IProduceService
    {
        /// <summary>
        /// 獲取初始化資料
        /// </summary>
        /// <returns>Produce物件</returns>
        public async Task<Produce> GetInitial() => await Task.Run(() => new Produce()
            {
                Id = 1,
                Name = "Yolo Producetion",
                Price = 567890,
                CreateTime = DateTime.Parse("2022/06/12"),
                SellingEndTime = DateTimeOffset.Now,
                SellingStarTime = DateTimeOffset.Now.AddDays(-2),
            });
    }
}
