using flight_manager_2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using flight_manager_2021.Models.Flights;
using flight_manager_2021.Shared;
using Data;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace flight_manager_2021.Controllers
{
    public class HomeController : Controller
    {
        private const int PageSize = 10;
        private readonly ConnectionDB _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new ConnectionDB();
        }

        public async Task<IActionResult> Index(FlightsIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            FlightsViewModel[] items = await _context.Flights.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new FlightsViewModel()
            {
                Id = c.Id,
                LocationFrom = c.LocationFrom,
                LocationTo = c.LocationTo,
                Going = c.TakeOffTime,
                Return = c.LandingTime,
                TypeOfPlane = c.TypeOfPlane,
                NameOfAviator = c.NameOfAviator,
                CapacityOfEconomyClass = c.CapacityOfEconomyClass,
                CapacityOfBusinessClass = c.CapacityOfBusinessClass,
                CountOfEconomyClass = c.CountOfEconomyClass,
                CountOfBusinessClass = c.CountOfBusinessClass
            }).ToArrayAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Flights.CountAsync() / (double)PageSize);

            return View(model);
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
