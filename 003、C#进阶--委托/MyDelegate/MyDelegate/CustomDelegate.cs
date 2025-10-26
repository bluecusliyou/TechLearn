namespace MyDelegate
{
    /// <summary>
    /// 1.无参数无返回值委托
    /// </summary>
    public delegate void NoReturnNoParaOutClass();

    public class CustomDelegate
    {
        /// <summary>
        /// 2.无参数无返回值委托
        /// </summary>
        public delegate void NoReturnNoPara();
        /// <summary>
        /// 3.有参数无返回值委托
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public delegate void NoReturnWithPara(int x, int y);
        /// <summary>
        /// 4.无参数有返回值的委托
        /// </summary>
        /// <returns></returns>
        public delegate int WithReturnNoPara();
        /// <summary>
        /// 5.带参数，带返回值的委托
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public delegate int WithReturnWithPara(out int x, ref int y);
    }
}
