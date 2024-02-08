using CoffeeJournal.Interfaces;
using CoffeeJournal.Models;
using Data;

namespace CoffeeJournal.Repository
{

    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly AppDbContext _context;

        
        public CoffeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Coffee GetCoffee(int coffeeId)
        {
            return _context.Coffees.Where(c => c.CoffeeId == coffeeId).FirstOrDefault();
        }
        public Coffee GetCoffeeBrand(string coffeBrand)
        {
            return _context.Coffees.Where(c =>  c.CoffeBrand == coffeBrand).FirstOrDefault();
        }

        public Coffee GetCoffeeName(string coffeName)
        {
            return _context.Coffees.Where(c =>  c.CoffeeName == coffeName).FirstOrDefault();

        }

        public ICollection<Coffee> GetCoffees()
        {
            return _context.Coffees.OrderBy(c => c.CoffeeId).ToList();
        }

        public bool CoffeeExists(int coffeeId) 
        {
            return _context.Coffees.Any(c => c.CoffeeId == coffeeId);
        }
    }
}
