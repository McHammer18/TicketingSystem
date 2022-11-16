using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_Test
{
    [TestClass]
    public class TicketRepositoryInMemoryTest
    {
        DbContextOptions<TicketContext> inmemory;

        public TicketRepositoryInMemoryTest()
        {
            inmemory = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("Filename=test.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        [TestMethod]
        public void GetAllTickets_HappyPath()
        {

            TicketContext cntx = new TicketContext(inmemory);
            cntx.Tickets.Add(new Ticket() { Id = 1, Name = "FirstTicket", Description = "Sprinter", Point = "3", SprintNum = "34", StatusId = "checkin" });
            cntx.Tickets.Add(new Ticket() { Id = 2, Name = "SecondTicket", Description = "Long Distance", Point = "5", SprintNum = "18", StatusId = "waiting" });
            cntx.SaveChanges();


            TicketRepository repo = new TicketRepository(cntx);
            var books = repo.GetAllTickets();

            Assert.AreEqual(2, books.Count());
        }

        [TestMethod]
        public void GetOddBooks_HappyPath()
        {
            var inmemory = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("Filename=test2.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            TicketContext cntx = new TicketContext(inmemory);
            cntx.Tickets.Add(new Ticket() { Id = 1, Name = "FirstTicket", Description = "Sprinter", Point = "3", SprintNum = "34", StatusId = "checkin" });
            cntx.Tickets.Add(new Ticket() { Id = 2, Name = "SecondTicket", Description = "Long Distance", Point = "5", SprintNum = "18", StatusId = "waiting" });
            cntx.Tickets.Add(new Ticket() { Id = 3, Name = "ThirdTicket", Description = "Mid Distance", Point = "4", SprintNum = "14", StatusId = "done" });
            cntx.Tickets.Add(new Ticket() { Id = 4, Name = "FourthTicket", Description = "Sprinter", Point = "2", SprintNum = "24", StatusId = "IR" });
            cntx.SaveChanges();


            TicketRepository repo = new TicketRepository(cntx);
            var tickets = repo.GetOddTickets();

            Assert.AreEqual(2, tickets.Count());
            Assert.AreEqual(1, tickets[0].Id);
            Assert.AreEqual(3, tickets[1].Id);
        }

    }
}
