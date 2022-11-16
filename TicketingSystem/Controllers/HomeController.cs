using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data.Common;
using System.Diagnostics;
using TicketingSystem.Models;
using TicketingSystem.Repository;

namespace TicketingSystem.Controllers
{
    public class HomeController : Controller
    {
        //Added dependancy injection with the Repository class
        private readonly ILogger<HomeController> _logger;
        private ITicketRepository ticketRepository;

        public HomeController(ILogger<HomeController> logger, ITicketRepository repo)
        {
            _logger = logger;
            ticketRepository = repo;
        }

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
           // ViewBag.Statuses = ticketRepository.GetStatus();

            List<Ticket> tickets = ticketRepository.GetAllTickets();

            return View(tickets);
        }
        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.Statuses = ticketRepository.GetStatus();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketRepository.InsertTicket(ticket);
                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag.Statuses = ticketRepository.GetStatus();
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
            var key = nameof(Ticket.Name);
            var val = ModelState.GetValidationState(key);
            if (val == ModelValidationState.Valid)
            {
                if (selected.StatusId == null)
                {
                    ticketRepository.DeleteTicket(selected);
                }
                else
                {
                    string newStatusId = selected.StatusId;
                    selected =ticketRepository.Find(selected.Id);
                    selected.StatusId = newStatusId;
                    ticketRepository.UpdateTicket(selected);
                }
            }
            ticketRepository.Save();

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