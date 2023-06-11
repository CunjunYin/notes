using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OwnedEntityTypes;

internal class Test
{
    public void Execute()
    {
        CleanDatabase();
        InitDatabase();

        using (var context = new DBContext())
        {
            foreach (var order in context.Orders)
            {
                Console.WriteLine($"{order.ShippingAddress.Street}, {order.ShippingAddress.City}");
            }

            foreach (var dstributor in context.Distributors)
            {
                foreach (var address in dstributor.ShippingCenters)
                {
                    Console.WriteLine($"{address.Street}, {address.City}");
                }
            }
        }
    }

    public static void InitDatabase()
    {
        using (var context = new DBContext())
        {
            var address1 = new StreetAddress()
            {
                Street = "143 Nicko Street",
                City = "Kata"
            };

            var address2 = new StreetAddress()
            {
                Street = "3 Wonder Ave",
                City = "Senifa"
            };

            var distributor = new Distributor();
            var order = new Order();
            distributor.ShippingCenters.Add(address1);
            distributor.ShippingCenters.Add(address2);
            order.ShippingAddress= address1;

            context.Distributors.Add(distributor);
            context.Orders.Add(order);

            context.SaveChanges();
        }
    }

    public static void CleanDatabase()
    {
        using (var context = new DBContext())
        {
            foreach (var blog in context.Orders)
            {
                context.Remove(blog);
            }

            foreach (var blog in context.Distributors)
            {
                context.Remove(blog);
            }
            context.SaveChanges();
        }
    }
}
