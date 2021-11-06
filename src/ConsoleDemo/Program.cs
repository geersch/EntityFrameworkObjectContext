using System;
using DAL;
using System.Linq;

namespace ConsoleDemo
{
    class Program
    {
        static void Main()
        {
            using (var context = new WestwindEntities())
            {
                // Query all the orders.
                var q = from o in context.Orders.Include("Customer") orderby o.Total select o;
                foreach(var order in q)
                {
                    Console.WriteLine(String.Format("{0} {1} has an order costing {2}.",
                                                    order.Customer.Firstname, order.Customer.Lastname,
                                                    order.Total));
                }
                Console.WriteLine();

                // Update the first order.
                Order firstOrder = q.FirstOrDefault();
                if (firstOrder != null)
                {
                    firstOrder.Total += 10;
                    context.SaveChanges();
                }

                // Display the order once more.
                foreach (var order in q)
                {
                    Console.WriteLine(String.Format("{0} {1} has an order costing {2}.",
                                                    order.Customer.Firstname, order.Customer.Lastname,
                                                    order.Total));
                }

                Console.ReadLine();
            }
        }
    }
}
