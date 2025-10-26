using Autofac.Extras.DynamicProxy;

namespace MyAutofac
{
    [Intercept(typeof(CustomInterceptor))]
    public interface IPhone
    {
        string ShowName();
    }
}
