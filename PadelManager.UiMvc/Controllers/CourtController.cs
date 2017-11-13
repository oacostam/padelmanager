using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PadelManager.Core.Interfaces;
using PadelManager.Services.Interfaces;
using PadelManager.Core.Models;
using PadelManager.UiMvc.Models;

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

        public ActionResult Create()
        {
            Court court = new Court();
            return View(court);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Court court)
        {
            if (ModelState.IsValid)
            {
                courtService.Create(court);
                return RedirectToAction("Index");
            }
            return View(court);
        }

        public ActionResult SelectCourt(int courtId)
        {
            Reservation reservation = new Reservation(){Court = new Court(){Id = courtId}, CreationdDate = DateTime.Now, CreatedBy = User.Identity.Name};
            return View("Book", reservation);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Book(Reservation reservation)
        {
            
            return RedirectToAction("Index");
        }
    }
}