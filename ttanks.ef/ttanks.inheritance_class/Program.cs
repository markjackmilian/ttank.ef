namespace ttanks.inheritance_class
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1())
            {
                context.Customer.Add(new MagicianCustomer
                {
                    FirstName = "Marco",
                    LastName = "Milani",
                    City = "Prato",
                    Country = "Italia",
                    Phone = "123",
                    MagicianLevel = 5

                });

                context.SaveChanges();
            }
        }
    }
}
