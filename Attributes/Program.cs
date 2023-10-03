namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Ali"
            };

            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            customerDal.AddNew(customer);
        }
    }

    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class RequiredPropertyAttribute : Attribute
    {
        
    }

    class ToTableAttribute : Attribute
    {
        private string tableName;
        public ToTableAttribute(string tableName)
        {
            this.tableName = tableName;
        }
    }

    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew method")]  // ---> in Java @Deprecated annotation
        public  void Add(Customer customer)
        {
            Console.WriteLine($"{customer.FirstName} added!");
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine($"{customer.FirstName} added with new add method!");
        }
    }
}