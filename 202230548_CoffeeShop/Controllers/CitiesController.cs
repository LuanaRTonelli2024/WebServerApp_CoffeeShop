using _202230548_CoffeeShop.Data;
using _202230548_CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _202230548_CoffeeShop.Controllers
{
    public class CitiesController : Controller
    {
        private readonly _202230548_CoffeeShopContext _context;

        public CitiesController(_202230548_CoffeeShopContext context)
        {
            _context = context;
        }



        // GET: Cities/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Cities/Search
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([Bind("CityId,Name,Province")] City city)
        {
            _context.Add(city);

            //search for many cars with a partial make
            List<City> foundCities = await _context.City
                .Where(searchedCity => 
                    (string.IsNullOrEmpty(city.Name) || searchedCity.Name.Contains(city.Name)) && 
                    (string.IsNullOrEmpty(city.Province) || searchedCity.Province.Contains(city.Province)))
                .ToListAsync();

            //convert search results into a JSON string and place it into TempData
            TempData["SearchResults"] = JsonConvert.SerializeObject(foundCities);
            return RedirectToAction("SearchResults"); //redirect to another action
        }

        public IActionResult SearchResults()
        {
            string resultsJson = TempData["SearchResults"] as string;
            var results = JsonConvert.DeserializeObject<List<City>>(resultsJson);

            if (results.Count > 0)
            {
                ViewBag.SearchResultMessage = "We found " + results.Count + " city(ies)";
            }
            else
            {
                ViewBag.SearchResultMessage = "No cities found";
            }
            return View(results);
        }



        // GET: Cities
        public async Task<IActionResult> Index()
        {
            return View(await _context.City.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,Name,Province")] City city)
        {
            if (ModelState.IsValid)
            {
                city.CityId = Guid.NewGuid();
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CityId,Name,Province")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.CityId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var city = await _context.City.FindAsync(id);
            if (city != null)
            {
                _context.City.Remove(city);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(Guid id)
        {
            return _context.City.Any(e => e.CityId == id);
        }
    }
}
