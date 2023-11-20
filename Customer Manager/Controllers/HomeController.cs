using Customer_Manager.Data;
using Customer_Manager.Data.DataModels;
using Customer_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Customer_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            List<CustomerModel> list = new();

            list.AddRange(_context.Customers.Where(e => e.IsActive && !e.IsDeleted));

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.CustomerList = list;
               

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}