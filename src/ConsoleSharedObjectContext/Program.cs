using System;
using DAL;
using System.Linq;

namespace ConsoleSharedObjectContext
{
    class Program
    {
        static void Main()
        {
            WestwindEntities context = SharedObjectContext.Instance.Context;

            var q = from o in context.Orders.Include("Customer") orderby o.Total select o;

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
