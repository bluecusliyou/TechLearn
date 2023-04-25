namespace MyAttribute.EnumExtend
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserState
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        [Remark("正常状态")]
        Normal = 0,
        /// <summary>
        /// 已冻结
        /// </summary>
        [Remark("已冻结")]
        Frozen = 1,
        /// <summary>
        /// 已删除
        /// </summary>
        [Remark("已删除")]
        Deleted = 2
    }
}
