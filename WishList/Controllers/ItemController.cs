using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Item> _items;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
            _items = _context.Items;
        }

        public IActionResult Index()
        {
            return View("Index", _items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            Item item = _items.Find(Id);
            _items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
