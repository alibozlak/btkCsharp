namespace Delegates
{
    internal class Program
    {
        public delegate void MyDelegate();     // <-- Delegate of No parameters and void return type methods
        public delegate void MyDelegate2(string text);

        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;
            myDelegate();
            Console.WriteLine("Minus SendMessage method from myDelegate :");
            myDelegate -= customerManager.SendMessage;
            myDelegate();

            Console.WriteLine("---------");

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;
            myDelegate2("Bla bla bla");
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be careful!");
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine("Hello! {0}", message);
        }

        public void ShowAlert2(string message)
        {
            Console.WriteLine("Be careful! {0}", message);
        }
    }
}