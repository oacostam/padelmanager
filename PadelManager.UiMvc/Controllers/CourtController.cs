using System.Web.Mvc;
using PadelManager.Core.Interfaces;
using PadelManager.Services.Interfaces;

namespace PadelManager.UiMvc.Controllers
{
    public class CourtController : Controller
    {
        private readonly ICourtService courtService;

        public CourtController(ICourtService courtService)
        {
            this.courtService = courtService;
        }

        public ActionResult Index(int? page, int? size)
        {
            int total;
            var courts = courtService.GetAll(page ?? 1, size ?? 10, out total);
            return View(courts);
        }
    }
}