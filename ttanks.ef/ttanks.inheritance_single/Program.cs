namespace ttanks.inheritance_single
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1())
            {
                context.Customer.Add(new SuperHeroCustomer
                {
                    FirstName = "Marco",
                    LastName = "Milani",
                    City = "Prato",
                    Country = "Italia",
                    Phone = "123",
                    SuperPower = "I can fly!"

                });

                context.SaveChanges();
            }
        }
    }
}
