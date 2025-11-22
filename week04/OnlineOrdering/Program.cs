using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address a1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            Customer c1 = new Customer("John Doe", a1);
            Order o1 = new Order(c1);
            o1.AddProduct(new Product("Keyboard", "P100", 25.0, 2));
            o1.AddProduct(new Product("Mouse", "P200", 10.0, 1));
            o1.AddProduct(new Product("Monitor", "P300", 150.0, 1));

            Address a2 = new Address("Rua das Flores 55", "Fortaleza", "CE", "Brazil");
            Customer c2 = new Customer("Maria Silva", a2);
            Order o2 = new Order(c2);
            o2.AddProduct(new Product("Laptop", "P400", 1200.0, 1));
            o2.AddProduct(new Product("Headphones", "P500", 80.0, 2));

            List<Order> orders = new List<Order> { o1, o2 };

            foreach (Order o in orders)
            {
                Console.WriteLine(o.GetPackingLabel());
                Console.WriteLine(o.GetShippingLabel());
                Console.WriteLine($"Total Price: {o.GetTotalCost():C}");
                Console.WriteLine();
            }
        }
    }
}
