using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    }
}