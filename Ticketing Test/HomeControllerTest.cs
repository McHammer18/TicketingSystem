using Castle.Core.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuGet.Frameworks;

namespace Ticketing_Test
{
    [TestClass]
    public class HomecontrollerTest
    {
        /// public IAction Index()
        /// {
        ///     ViewBag.Name = "Studnet";
        ///     
        ///     List<Ticket> tickets = ticketRepository.GetAllTickets();
        /// }

        [TestMethod]
        public void Index_Happy()
        {
            //Arange
            var logger = new Mock<ILogger<HomeController>>();
            var trMock = new Mock<ITicketRepository>();
            List<Ticket> lst = new List<Ticket>()
            {
                new Ticket() {Id = 1, Name = "FirstTicket", Description="Sprinter", Point="3", SprintNum="34", StatusId = "checkin"},
                new Ticket() {Id = 2, Name = "SecondTicket", Description="Long Distance", Point="5", SprintNum="18", StatusId = "waiting"}
            };

            trMock.Setup(r => r.GetAllTickets()).Returns(lst);

            HomeController ctrl = new HomeController(logger.Object, trMock.Object);

            //Action
            var result = ctrl.Index("all");

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var vr = result as ViewResult;
            Assert.IsInstanceOfType(vr.Model, typeof(List<Ticket>));
            var mdl = vr.Model as List<Ticket>;
            Assert.AreEqual(2, mdl.Count());
        }
    }
}