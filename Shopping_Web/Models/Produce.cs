using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Shopping_Web.Models
{
    [DataContract]
    public sealed class Produce
    {
        [DisplayName("Id")]
        [DataMember]
        public int Id { get; set; }

        [DisplayName("商品")]
        [DataMember]
        public string Name { get; set; }

        [DisplayName("價格")]
        [DataMember]
        public decimal Price { get; set; }

        [DisplayName("發售日")]
        [DataMember]
        public DateTimeOffset SellingStarTime { get; set; }

        [DisplayName("下架日")]
        [DataType(DataType.DateTime)]
        [DataMember]
        public DateTimeOffset? SellingEndTime { get; set; }

        [DisplayName("建立時間")]
        [DataType(DataType.DateTime)]
        [DataMember]
        public DateTimeOffset CreateTime { get; set; }
    }
}
