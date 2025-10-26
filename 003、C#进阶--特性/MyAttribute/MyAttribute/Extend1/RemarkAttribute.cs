using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    /// <summary>
    /// 是给枚举用  提供一个额外信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            this.Remark = remark;
        }

        public string Remark { get; private set; }
    }

    public static class RemarkExtend
    {
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo field = type.GetField(enumValue.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute remarkAttribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute));
                return remarkAttribute.Remark;
            }
            else
            {
                return enumValue.ToString();
            }
        }
    }

    [Remark("用户状态")]
    public enum UserState
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Remark("正常")]
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Frozen = 1,
        /// <summary>
        /// 删除
        /// </summary>
        [Remark("删除")]
        Deleted = 2
    }
}
