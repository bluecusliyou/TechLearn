using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGeneric
{
    /// <summary>
    /// 只能放在接口或者委托的泛型参数前面
    /// out 协变covariant    修饰返回值 
    /// in  逆变contravariant  修饰传入参数
    /// </summary>
    public class GenericCCTest
    {
        public static void Show()
        {
            {
                Bird bird1 = new Bird();
                Bird bird2 = new Sparrow();
                Sparrow sparrow1 = new Sparrow();
            }

            {
                List<Bird> birdList1 = new List<Bird>();
                List<Bird> birdList3 = new List<Sparrow>().Select(c => (Bird)c).ToList();
                //List<Bird> birdList2 = new List<Sparrow>();
            }

            {
                //协变
                IEnumerable<Bird> birdList1 = new List<Bird>();
                IEnumerable<Bird> birdList2 = new List<Sparrow>();

                //委托协变
                Func<Bird> func = new Func<Sparrow>(() => null);

                //自定义协变
                ICustomerListOut<Bird> customerList1 = new CustomerListOut<Bird>();
                ICustomerListOut<Bird> customerList2 = new CustomerListOut<Sparrow>();
            }

            {
                //自定义逆变
                ICustomerListIn<Sparrow> customerList2 = new CustomerListIn<Sparrow>();
                ICustomerListIn<Sparrow> customerList1 = new CustomerListIn<Bird>();

                ICustomerListIn<Bird> birdList1 = new CustomerListIn<Bird>();
                birdList1.Show(new Sparrow());
                birdList1.Show(new Bird());

                Action<Sparrow> act = new Action<Bird>((Bird i) => { });
            }

            {
                IMyList<Sparrow, Bird> myList1 = new MyList<Sparrow, Bird>();
                IMyList<Sparrow, Bird> myList2 = new MyList<Sparrow, Sparrow>();//协变
                IMyList<Sparrow, Bird> myList3 = new MyList<Bird, Bird>();//逆变
                IMyList<Sparrow, Bird> myList4 = new MyList<Bird, Sparrow>();//协变+逆变
            }
        }
    }

    public class Bird
    {
        public int Id { get; set; }
    }
    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// in 逆变
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListIn<in T>
    {
        void Show(T t);
    }

    public class CustomerListIn<T> : ICustomerListIn<T>
    {
        public void Show(T t)
        {

        }
    }

    /// <summary>
    /// out 协变 只能是返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T>
    {
        T Get();
    }

    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }
    }

    /// <summary>
    /// inT  逆变
    /// outT 协变
    /// </summary>
    /// <typeparam name="inT"></typeparam>
    /// <typeparam name="outT"></typeparam>
    public interface IMyList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);
    }

    public class MyList<T1, T2> : IMyList<T1, T2>
    {
        public void Show(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
        }

        public T2 Get()
        {
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }

        public T2 Do(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }
    }
}
