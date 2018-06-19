namespace p01.Intro
{
    using System;
    using System.Reflection;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var type = typeof(StringBuilder);
            var constructor = type.GetConstructor(new Type[] { typeof(string), typeof(int) });
            //var paramaterType = constructor.GetParameters();
            StringBuilder sb = (StringBuilder)constructor.Invoke(new object[] { "Gosho", 15 });
            ;

            var appendMethod = type.GetMethod("Append", new Type[] { typeof(string) });
            appendMethod.Invoke(sb, new object[] { "Append Line" });
            ;




















            //var sb = (StringBuilder)Activator.CreateInstance(typeof(StringBuilder), "Put content");
            var testType = typeof(TestReflection);
            ////BindingFlags.Instance означава искам да върнеш полета, които се инстанцират при инициализацията на полето.
            //var fields = testType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            //FieldInfo field = testType.GetField("name",BindingFlags.Instance | BindingFlags.NonPublic);
            //string fieldName = field.Name;
            //Type fieldType = field.FieldType;

            //var testReflection = (TestReflection)Activator.CreateInstance(testType, new object[] { 15 });
            //Console.WriteLine(testReflection.Number);

            //var newField = testType.GetField("number", BindingFlags.NonPublic | BindingFlags.Instance);
            //newField.SetValue(testReflection, 7);
            //var fieldValue = (int)newField.GetValue(testReflection);
            //Console.WriteLine(fieldValue);
            //Console.WriteLine(testReflection.Number);



            ConstructorInfo[] constructorInfos = testType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            ;
        }
    }
}
