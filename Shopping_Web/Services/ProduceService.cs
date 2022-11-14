using System.Reflection;
using System.Text;
using System.Text.Json;
using Shopping_Web.Models;
using Shopping_Web.Services.Interface;
using Shopping_Web.Internal;

namespace Shopping_Web.Services
{
    public class ProduceService : IProduceService
    {
        private const string PRODUCE_DIC_NAME = "produce";
        private const string UNMEAN_DIC_NAME = "unmean";

        private readonly string _middleCloudUrl = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-D0047-089?Authorization=CWB-0ECF92FF-1305-4B2E-8E01-2FFA1C4759FA&limit=1";

        private readonly HttpClient _client;

        private readonly Dictionary<string, string> _produceDic = new ()
        {
            {"Id","ID"},
            {"Name","NAME"},
            {"Price","PRICE"},
            {"SellingStarTime","SELLINGSTARTIME"},
            {"SellingEndTime","SELLINGENDTIME"},
            {"CreateTime","CREATETIME"},
        };

        private readonly Dictionary<string, string> _unMeanDic = new ()
        {
            {"LogNo", "LOGNO"},
            {"Yolo", "YOLO" },
            {"ExceptionMsg", "EXCEPTIONMSG" },
        };

        public ProduceService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
        }

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
    
        /// <summary>
        /// 採用後端 service 獲取 Get資料
        /// </summary>
        /// <returns>Get物件</returns>
        public async Task<MiddleResult> GetRequestData()
        {
            var middleResult = new MiddleResult();

            using (var request = new HttpRequestMessage(HttpMethod.Get, _middleCloudUrl) )
            {
                var response = await _client.SendAsync(request);

                if( response.IsSuccessStatusCode)
                {
                    var respStr = await response.Content.ReadAsStringAsync();

                    middleResult = JsonSerializer.Deserialize<MiddleResult>(respStr);
                }
            }

            return middleResult;
        }

        /// <summary>
        /// 測試Property屬性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic">Json回傳資料</param>
        public async Task GetPropertyTesting<T>(Dictionary<string, JsonElement> dic) => await Task.Run(() =>
        {
            var typeObj = new Produce().GetType();
            var props = typeObj.GetProperties();

            this.GetData(new Produce() { Id = 1234 } );
            this.GetProperty<Produce>();
        });

        //使用Type存取所有Public屬性名稱及屬性值
        private void GetData(object obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties();
            var sb = new StringBuilder();
            foreach (var property in properties)
            {
                sb.AppendLine($"{property.Name} = {property.GetValue(obj)?.ToString()}");
            }

            System.Diagnostics.Debug.WriteLine($"Name/Value : {sb.ToString()}");
        }

        /// <summary>
        /// 取得並顯示Property屬性部分資訊
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void GetProperty<T>()
        {
            var type = typeof(T);

            var sb = new StringBuilder();
            // type 屬性資料
            sb.AppendLine($"IsArray: {type.IsArray}");
            sb.AppendLine($"IsClass: {type.IsClass}");
            sb.AppendLine($"IsEnum: {type.IsEnum}");
            sb.AppendLine($"IsInterface: {type.IsInterface}");
            sb.AppendLine($"IsPublic: {type.IsPublic}");
            sb.AppendLine($"IsGenericType: {type.IsGenericType}");
            sb.AppendLine($"IsValueType: {type.IsValueType}");

            var typeInfo = type.GetTypeInfo();
            var declareMem = typeInfo.DeclaredMembers;
            foreach(var member in declareMem)
            {
                sb.AppendLine($"MemberName: {member.Name}");
                sb.AppendLine($"MemberType: {member.MemberType}");
            };

            System.Diagnostics.Debug.WriteLine(sb.ToString());
        }

        private Dictionary<string, string> GetSpecificDic(string spcificStr)
        {
            var dic = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(spcificStr))
                return dic;

            spcificStr = spcificStr.ToLowerInvariant();

            var dicName = (ConvertDic)Enum.Parse(typeof(ConvertDic), spcificStr);

            switch (dicName)
            {
                case ConvertDic.Produce:
                    dic = new Dictionary<string, string>(_produceDic);
                    break;
                case ConvertDic.Unmean:
                    dic = new Dictionary<string, string>(_unMeanDic);
                    break;
            }

            return dic;
        }
    }
}
