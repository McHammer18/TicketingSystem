using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Diagnostics;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TicketContext context;

        public HomeController(ILogger<HomeController> logger, TicketContext dbcontext)
        {
            _logger = logger;
            context = dbcontext;
        }

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();

            IQueryable<Ticket> query = context.Tickets;
            if (filters.HasName)
            {
                query = query.Where(t=> t.Name == filters.Name);
            }
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            if (filters.HasSprintNumber)
            {
                query = query.Where(t => t.SprintNum == filters.SprintNum);
            }
            if (filters.HasPointValue)
            {
                query = query.Where(t => t.Point == filters.Point);
            }
            var tickets = query;

            return View(tickets);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = context.Statuses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Statuses = context.Statuses.ToList();
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Ticket selected)
        {
            if (selected.StatusId == null)
            {
                context.Tickets.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Tickets.Find(selected.Id);
                selected.StatusId = newStatusId;
                context.Tickets.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
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