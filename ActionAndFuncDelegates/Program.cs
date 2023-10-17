namespace ActionAndFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 15, 16, 17, 18 };

            Console.WriteLine("------ Action --------");

            Action action1 = () =>
            {
                Console.WriteLine(intArray[12]);
            };

            ExceptionHandle(action1);

            Console.WriteLine("---------");

            ExceptionHandle(() =>
            {
                intArray[0] = 20;
                Console.WriteLine(intArray[0]);
            });

            Console.WriteLine("------ Func --------");

            Func<int, bool> func1 = (int integer) => integer > 17;

            List<int> greaterThan17ints = FilterArray(func1, intArray);
            foreach (var integer in greaterThan17ints)
            {
                Console.Write(integer + " ");
            }
            Console.WriteLine("\n----");

            List<int> lessThan17ints = FilterArray((int integer) => integer < 17, intArray);
            foreach (var integer in lessThan17ints)
            {
                Console.Write(integer + " ");
            }
            Console.WriteLine();
        }

        private static void ExceptionHandle(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine("Dizinin olmayan bir indexini okumaya çalışitınız!!! Message : ");
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static List<int> FilterArray(Func<int,bool> func, int[] integers) 
        {
            List<int> resultList = new List<int>();
            foreach (int integer in integers)
            {
                if (func.Invoke(integer))
                {
                    resultList.Add(integer);
                }
            }
            return resultList;
        }
    }
}