using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;      
        }

        public IActionResult Index()
        {
            var people = _context.People.ToList();
            return View(people);
        }

        public IActionResult Details(int? id)
        {
            if( id == null )
            {
                return NotFound();
            }

            var person = _context.People.SingleOrDefault(
                p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: /Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Home/Create
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Home/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.People.SingleOrDefault(
                p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: /Home/Edit
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Home/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.People.SingleOrDefault(
                p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: /Home/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = _context.People.SingleOrDefault(
                p => p.Id == id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
