namespace EventsLastLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product hardDisk = new Product("Hard Disk", 42);
            Product mobilePhone = new Product("iPhone XI", 42);

            mobilePhone.StockControlEvent += MobilePhone_StockControlEvent;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("---- {0}. Satış ----",i+1);
                hardDisk.Sell(10);
                mobilePhone.Sell(10);
                Console.ReadKey();
            }
        }

        private static void MobilePhone_StockControlEvent()
        {
            Console.WriteLine("STOKTA iPhone XI AZALDI, LÜTFEN SİPARİŞ VER!!");
        }
    }
}