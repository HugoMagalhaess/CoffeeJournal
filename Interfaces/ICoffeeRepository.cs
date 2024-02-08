using CoffeeJournal.Models;

namespace CoffeeJournal.Interfaces
{
    public interface ICoffeeRepository
    {
        ICollection<Coffee> GetCoffees();

       Coffee GetCoffee(int coffeeId);   
       Coffee GetCoffeeName(string coffeName);
       Coffee GetCoffeeBrand(string coffeBrand);
       
        bool CoffeeExists(int coffeeId);
    }
}
