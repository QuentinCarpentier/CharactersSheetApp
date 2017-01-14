using Microsoft.AspNetCore.Mvc;
using CharactersSheetApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CharactersSheetApp.Controllers
{
    public class CharacterController : Controller
    {
        // Context property
        private readonly ApplicationDbContext _context;

        // Constructor injection
        public CharacterController(ApplicationDbContext context)
        {
            // Inject ApplicationDbContext in our controller
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Character character)
        {
            // For create a character, we call the Add() method (like a List)
            _context.Characters.Add(character);
            // Each time we submit data, we save changes and redirect to action to prevent accidental submissions
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Index method is in fact our GetAll() method
        public IActionResult Index()
        {
            // ToList: convert a collection (here DbSet collection) to List collection
            var model = _context.Characters.ToList();
            return View(model);
        }

        public IActionResult GetActive()
        {
            // Lambda expression for condensed foreach loop
            // Here, returns active characters (IsActive is True)
            var model = _context.Characters.Where(e => e.IsActive).ToList();
            return View(model);
        }

        public IActionResult Details(string name)
        {
            // FirstOrDefault: returns only one record instead of a collection
            // Lambda expression for comparing values: returns the correct character based of his name
            var model = _context.Characters.FirstOrDefault(n => n.Name == name);
            return View(model);
        }

        public IActionResult Update(Character character)
        {
            // DbSet Entry() method: locate and update our data
            // Then, set its state to modified for letting EntityFramework know we've change that data
            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string name)
        {
            var original = _context.Characters.FirstOrDefault(n => n.Name == name);

            // Validation: Makes sure we have a character to remove
            if (original != null)
            {
                // DbSet Remove() method for remove something from the db
                _context.Characters.Remove(original);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
