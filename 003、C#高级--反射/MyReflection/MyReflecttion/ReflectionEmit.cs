using System;
using System.Reflection;
using System.Reflection.Emit;

namespace MyReflecttion
{
    public class MyDynamicType
    {
        /// <summary>
        /// 字段
        /// </summary>
        public int NumberField = 0;       

        /// <summary>
        /// int类型参数构造函数
        /// </summary>
        /// <param name="numberField"></param>
        public MyDynamicType(int numberField)
        {
            this.NumberField = numberField;
        }

        /// <summary>
        /// 无参数方法
        /// </summary>
        public void ConsoleMethod()
        {
            Console.WriteLine("方法输出的内容");
        }

        /// <summary>
        /// 有参数方法
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int MyMethod(int para)
        {
            return 2 * para;
        }
    }

    public class ReflectionEmit
    {
        //一般的，使用反射发出（reflection emit）可能会是这样子的步骤
        //（1）创建一个新的程序集
        //程序集是动态的存在于内存中或把它们保存到磁盘上
        //（2）在程序集内部，创建一个模块
        //（3）在模块内部，创建一个类型
        //（4）给类型添加属性和方法
        //（5）产生属性和方法内部的代码
        public static void Show()
        {

            //（1）创建一个新的程序集
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAssemblyExample"), AssemblyBuilderAccess.RunAndCollect);

            //（2）在程序集内部，创建一个模块
            ModuleBuilder modulebuilder = assemblyBuilder.DefineDynamicModule("MyModal");

            //（3）在模块内部，创建一个类型
            TypeBuilder typebuilder = modulebuilder.DefineType("MyDynamicType", TypeAttributes.Public);

            //（4）给类型添加属性和方法
            // 在Type中生成字段
            FieldBuilder fieldBuilder = typebuilder.DefineField("NumberField", typeof(int), FieldAttributes.Public);

            #region 定义一个接受整数参数的构造函数
            //（4）给类型添加属性和方法
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = typebuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);

            //（5）产生属性和方法内部的代码
            //中间语言的生成者
            ILGenerator ctor1IL = ctor1.GetILGenerator();
            //对于构造函数，参数0是对新 
            //实例。在调用base之前将其推到堆栈上 
            //类构造函数。指定的默认构造函数
            //类型（Type.EmptyTypes）到GetConstructor。
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            //在推送参数之前，先将实例推送到堆栈上 
            //将被分配给私有字段m\u编号。 
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, fieldBuilder);
            ctor1IL.Emit(OpCodes.Ret);//写IL最后一定要Ret

            //测试代码
            {
                //Type type1 = typebuilder.CreateType();
                //object oInstacne = Activator.CreateInstance(type1, new object[] { 123456 });
                //FieldInfo fieldInfo = type1.GetField("NumberField");
                //object numberFieldResult = fieldInfo.GetValue(oInstacne);
            }
            #endregion

            #region 定义一个无参数方法
            //（4）给类型添加属性和方法
            MethodBuilder consoleMethod = typebuilder.DefineMethod("ConsoleMethod", MethodAttributes.Public | MethodAttributes.Static, null, null);

            //（5）产生属性和方法内部的代码
            ILGenerator consoleMethodIL = consoleMethod.GetILGenerator();
            consoleMethodIL.Emit(OpCodes.Ldstr, "方法输出的内容");
            consoleMethodIL.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
            consoleMethodIL.Emit(OpCodes.Ret); 

            //测试代码
            {
                //Type type1 = typebuilder.CreateType();
                //object oInstacne = Activator.CreateInstance(type1, new object[] { 123456 });
                //MethodInfo myMethod = type1.GetMethod("ConsoleMethod");
                //object oResult = myMethod.Invoke(oInstacne, null);
            }
            #endregion

            #region 定义一个有参数方法
            //（4）给类型添加属性和方法
            MethodBuilder AddMethod = typebuilder.DefineMethod("MyMethod", MethodAttributes.Public | MethodAttributes.Static, typeof(int), new Type[] { typeof(int), typeof(int) });

            //（5）产生属性和方法内部的代码
            ILGenerator AddMethodIL = AddMethod.GetILGenerator();
            AddMethodIL.Emit(OpCodes.Ldarg_0);
            AddMethodIL.Emit(OpCodes.Ldarg_1);
            AddMethodIL.Emit(OpCodes.Add_Ovf_Un);
            AddMethodIL.Emit(OpCodes.Ret);

            //测试代码
            {                
                //Type type1 = typebuilder.CreateType();
                //object oInstacne = Activator.CreateInstance(type1, new object[] { 123456 });
                //MethodInfo myMethod = type1.GetMethod("MyMethod");
                //object oResult = myMethod.Invoke(oInstacne, new object[] { 12, 34 });
            }
            #endregion
        }
    }
}
