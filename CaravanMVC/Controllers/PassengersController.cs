using CaravanMVC.DataAccess;
using CaravanMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.Controllers
{
    public class PassengersController : Controller
    {
        private readonly CaravanMvcContext _context;

        public PassengersController(CaravanMvcContext context)
        {
            _context = context;
        }

        [Route("wagons/{id:int}/passengers")]
        public IActionResult Index(int id)
        {
            var wagonPassengers = _context.Wagons
                .Where(w => w.Id == id)
                .Include(w => w.Passengers)
                .FirstOrDefault();

            return View(wagonPassengers);
        }

        [Route("wagons/{id:int}/passengers/new")]
        public IActionResult New(int id)
        {
            var wagonPassengers = _context.Wagons
                .Where(w => w.Id == id)
                .Include(w => w.Passengers)
                .FirstOrDefault();

            return View(wagonPassengers);
        }

        [HttpPost]
        [Route("wagons/{id:int}/passengers")]
        public IActionResult Create(string Name, int Age, string Destination, int id)
        {
            var wagon = _context.Wagons
                .Where(w => w.Id == id)
                .Include(w => w.Passengers)
                .FirstOrDefault();

            var passenger = new Passenger(Name, Age, Destination);
            wagon.Passengers.Add(passenger);
            _context.SaveChanges();

            return Redirect($"/wagons/{wagon.Id}");
        }
    }
}
