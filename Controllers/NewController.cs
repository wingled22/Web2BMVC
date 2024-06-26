using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Web2BMVC.Entities;

namespace Web2BMVC.Controllers
{
    public class NewController : Controller
    {
        private readonly LibraryContext _context ; 

        public NewController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Books.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b){
            
            if(!ModelState.IsValid)
                return View(b); 

            _context.Books.Add(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id){
            var book = _context.Books.Where( q => q.Id == id).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book b){

            if(!ModelState.IsValid)
                return View(b); 
    
            _context.Books.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id){
            var book = _context.Books.Where( q => q.Id == id).FirstOrDefault();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");;
        }

    }
}