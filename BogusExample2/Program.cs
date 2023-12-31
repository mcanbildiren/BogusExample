﻿using Bogus;
using BogusExample2.Entities;
using BogusExample2.Models.Entities;
using BogusExample2.Models.Enums;
using Newtonsoft.Json;

namespace BogusExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Randomizer.Seed = new Random(3333);

            var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };

            var orderIds = 0;
            var testOrders = new Faker<Order>("tr")
                .StrictMode(true)
                .RuleFor(o => o.OrderId, f => orderIds++)
                .RuleFor(o => o.Item, f => f.PickRandom(fruit))
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
                .RuleFor(o => o.LotNumber, f => f.Random.Int(0, 100).OrNull(f, .8f));

            var userIds = 0;
            var testUsers = new Faker<User>("tr")
                .CustomInstantiator(f => new User(userIds++, f.Random.Replace("###-##-####")))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.SomethingUnique, f => $"Value {f.UniqueIndex}")
                .RuleFor(u => u.SomeGuid, Guid.NewGuid)
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.CartId, f => Guid.NewGuid())
                .RuleFor(u => u.FullName, (f, u) => u.FirstName + " " + u.LastName)
                .RuleFor(u => u.Orders, f => testOrders.Generate(4))
                .FinishWith((f, u) =>
                {
                    Console.WriteLine("User Created! Name = {0}", u.FullName);
                });

            var user = testUsers.Generate(3);

            var result = JsonConvert.SerializeObject(user, Formatting.Indented);
            Console.WriteLine(result);
        }
    }
}