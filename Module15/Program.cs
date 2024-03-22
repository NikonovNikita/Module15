using Module15.Models;
using System.Text;

namespace Module15;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;


    }

    static void GroupingByKey(List<Contact> contacts)
    {
        var emailsGrouped = from contact in contacts
                            group contact by contact.EMail.Split("@").Last() into TwoGroups
                            where TwoGroups.Key != "example.com"
                            select TwoGroups;

        foreach (var e in emailsGrouped)
        {
            Console.WriteLine($"Ключ {e.Key}:");
            foreach (var element in e)
                Console.WriteLine($"\t{element.EMail}");
            Console.WriteLine();
        }
    }

    static void JoinMethod(List<Car> cars, List<Manufacturer> manufacturers)
    {
        var result = from car in cars
                     join m in manufacturers on car.Manufacturer equals m.Name
                     select new
                     {
                         Name = car.Model,
                         Manufacturer = m.Name,
                         m.Country
                     };

        var result2 = cars.Join(manufacturers,
            car => car.Manufacturer,
            m => m.Name,
            (car, m) => new
            {
                Name = car.Model,
                Manufacturer = m.Name,
                m.Country
            });
    }

    static void GroupJoinMethod(List<Car> cars, List<Manufacturer> manufacturers)
    {
        var result = manufacturers.GroupJoin(cars, m => m.Name, car => car.Manufacturer,
            (m, cars) => new
            {
                m.Name,
                m.Country,
                Cars = cars.Select(s => s.Model)
            });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} --> {item.Country}");
            foreach (var car in item.Cars)
                Console.WriteLine($"{car}");
            Console.WriteLine();
        }
    }
}