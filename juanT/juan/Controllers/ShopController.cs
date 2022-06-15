using juan.DAL;
using juan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juan.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext db;
        public ShopController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            ShopViewModels svm = new ShopViewModels
            {
                categories = await db.Categories.ToListAsync(),
                products = await db.Products.ToListAsync()
            };
            return View(svm);
        }
    }
}
