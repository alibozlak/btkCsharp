namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> cities = utilities.BuildList<string>("Ankara", "İzmir", "Aydın", "İstanbul");

            foreach (var cityName in cities)
            {
                Console.WriteLine(cityName);
            }
            Console.WriteLine("---------");

            Customer customer1 = new Customer
            {
                FirstName = "Ali İhsan"
            };
            Customer customer2 = new Customer
            {
                FirstName = "Engin"
            };
            List<Customer> customers = utilities.BuildList<Customer>(customer1, customer2);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.ReadLine();
        }
    }

    interface IEntity
    {
        
    }

    class Product : IEntity
    {

    }

    interface IProductDal : IRepository<Product>
    {
        //List<Product> GetAll();
        //Product GetById(int id);
        //bool Add(Product product);
        //bool Update(Product product);
    }

    class Customer : IEntity
    {
        public string FirstName { get; set; }
    }

    interface ICustomerDal : IRepository<Customer>
    {
    }

    interface IRepository<T> where T : class, IEntity, new()    // class -> reference type constraint
    {
        List<T> GetAll();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
    }

    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        } 
    }
}