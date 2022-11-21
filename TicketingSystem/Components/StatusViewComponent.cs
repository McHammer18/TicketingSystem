using Microsoft.AspNetCore.Mvc;

namespace TicketingSystem.Components
{
    public class StatusViewComponent : ViewComponent
    {
        private IStatus status { get; set; }

        public StatusViewComponent(IStatus s)
        {
            status = s;
        }

        public IViewComponentResult Invoke()
        {
            return View(status);
        }

    }
}
