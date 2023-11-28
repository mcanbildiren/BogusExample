using Bogus;
using BogusExample.Entities;

var userFaker = new Faker<User>("tr")
    .RuleFor(u => u.Id, f => f.IndexFaker)
    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
    .RuleFor(u => u.LastName, f => f.Name.LastName())
    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName, "hangikredi.com"))
    .RuleFor(u => u.Iban, f => f.Finance.Iban(false,"tr"))
    .RuleFor(u => u.Date, f => f.Date.Future(10));

var users = userFaker.Generate(3);

foreach (var item in users)
{
    Console.WriteLine(item.Id + ", " + item.FirstName + " " + item.LastName + ", " + item.Email + ", " + item.Iban + ", " + item.Date);
}

var addressFaker = new Faker<Address>("tr")
    .RuleFor(a => a.StreetAddress, f => f.Address.StreetAddress())
    .RuleFor(a => a.City, f => f.Address.City())
    .RuleFor(a => a.State, f => f.Address.State())
    .RuleFor(a => a.ZipCode, f => f.Address.ZipCode())
    .RuleFor(a => a.Country, f => f.Address.Country());

var addresses = addressFaker.Generate(1);

foreach (var item in addresses)
{
    Console.WriteLine(item.StreetAddress + ", " + item.City + " " + item.State + ", " + item.ZipCode + ", " + item.Country);
}