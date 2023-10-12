using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Math math = new Math(2, 3);
            //int sum1 = math.Sum(5, 6);
            //int sum2 = math.Sum2();
            //Console.WriteLine(sum1);
            //Console.WriteLine(sum2);

            var type = typeof(Math);

            //var math = Activator.CreateInstance(type);    // <-- Runtime new
            
            //Math math = (Math) Activator.CreateInstance(type,4,5);
            //Console.WriteLine(math.Sum2());

            var instance = Activator.CreateInstance(type,16,7);
            MethodInfo methodInfo = instance.GetType().GetMethod("Sum2");
            Console.WriteLine(methodInfo.Invoke(instance, null));

            Console.WriteLine("-----------");

            var methods = instance.GetType().GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"*** Method name : {method.Name} ***");
                foreach (var parameter in method.GetParameters())
                {
                    Console.WriteLine($"Parameter name : {parameter.Name}");
                }
                foreach (var attribute in method.GetCustomAttributes())
                {
                    Console.WriteLine($"Attribute name : {attribute.GetType().Name}");
                }
            }
        }
    }

    class Math
    {
        private int _number1;
        private int _number2;

        public Math(int number1, int number2)
        {
            _number1 = number1;
            _number2 = number2;
        }

        public int Sum(int number1,  int number2)
        {
            return number1 + number2;
        }

        public int Multiple(int number1, int number2)
        {
            return number1 * number2;
        }

        public int Sum2()
        {
            return _number1 + _number2;
        }

        [MethodName("Multiplication")]
        public int Multiple2()
        {
            return _number1 * _number2;
        }
    }

    public class MethodNameAttribute : Attribute
    {
        private string _name;
        public MethodNameAttribute(string name)
        {
            _name = name;
        }
    }
}