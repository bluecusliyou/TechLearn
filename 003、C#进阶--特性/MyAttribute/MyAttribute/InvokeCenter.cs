using System;

namespace MyAttribute
{
    public class InvokeCenter
    {
        public static void ManagerStudent<T>(T student) where T : Student
        {
            Console.WriteLine($"{student.Id}_{student.Name}");
            student.Study();
            student.Answer("123");

            Type type = student.GetType();
            if (type.IsDefined(typeof(CustomAttribute), true))
            {
                //type.GetCustomAttribute()
                object[] oAttributeArray = type.GetCustomAttributes(typeof(CustomAttribute), true);
                foreach (CustomAttribute attribute in oAttributeArray)
                {
                    attribute.Show();
                    //attribute.Description
                }

                foreach (var prop in type.GetProperties())
                {
                    if (prop.IsDefined(typeof(CustomAttribute), true))
                    {
                        object[] oAttributeArrayProp = prop.GetCustomAttributes(typeof(CustomAttribute), true);
                        foreach (CustomAttribute attribute in oAttributeArrayProp)
                        {
                            attribute.Show();
                        }
                    }
                }
                foreach (var method in type.GetMethods())
                {
                    if (method.IsDefined(typeof(CustomAttribute), true))
                    {
                        object[] oAttributeArrayMethod = method.GetCustomAttributes(typeof(CustomAttribute), true);
                        foreach (CustomAttribute attribute in oAttributeArrayMethod)
                        {
                            attribute.Show();
                        }
                    }
                }
            }
        }
    }
}
