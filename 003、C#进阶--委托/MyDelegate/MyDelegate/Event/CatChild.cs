namespace MyDelegate.Event
{
    public class CatChild:Cat
    {
        public void Show()
        {
            base.MiaoDelegateHandler.Invoke(); //子类中执行父类中多播委托
            //base.MiaoEventHanlder.Invoke();//子类中无法访问到父类中的事件
        }
    }
}
