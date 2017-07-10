#region

using System.Collections.Generic;
using System.Web.Mvc;
using PadelManager.Core.Models;
using PadelManager.Services.Interfaces;

#endregion

namespace PadelManager.UiMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUnpayedReservations()
        {
            IEnumerable<Reservation> unpayed = userService.GetUnpayedReservations(1);
            return new EmptyResult();
        }
    }
}