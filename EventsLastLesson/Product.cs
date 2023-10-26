using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsLastLesson
{
    public delegate void StockControl();
    public class Product
    {
        private int _stockAmount;
        public Product(string productName, int stockAmount)
        {
            _stockAmount = stockAmount;
            ProductName = productName;
        }

        public event StockControl StockControlEvent;
        public string ProductName { get; set; }
        public int StockAmount
        {
            get { return _stockAmount; }
            set
            {
                _stockAmount = value;
                if (value <= 20 && StockControlEvent != null)
                {
                    StockControlEvent();
                }
            }
        }

        public void Sell(int amount)
        {
            if (amount <= _stockAmount)
            {
                StockAmount -= amount;
                Console.WriteLine($"{ProductName} stok miktarı : {StockAmount}");
            } else
            {
                Console.WriteLine($"Stokta {ProductName} ürününden {amount} adet maalesef ki yok!! Satış yapılamadı!!");
            }
        }
    }
}
