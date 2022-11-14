using System.ComponentModel;
using System.Runtime.Serialization;

namespace Shopping_Web.Internal
{
    /// <summary>
    /// 轉換字典
    /// </summary>
    public enum ConvertDic
    {
        /// <summary>
        /// Produce物件
        /// </summary>
        [EnumMember, Description("Produce")]
        Produce,

        /// <summary>
        /// 非定義
        /// </summary>
        [EnumMember, Description("Unmean")]
        Unmean,
    }
}
