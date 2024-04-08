using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using LabBookingApp.Service.Interface;
using System.Security.Claims;

namespace LabBookingApp.Web.Controllers
{
    public class BookingListsController : Controller
    {
        private readonly IBookingListService _bookingListService;

        public BookingListsController(IBookingListService bookingListService)
        {
            _bookingListService = bookingListService;
        }

        // GET: BookingLists
        public IActionResult Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = _bookingListService.getBookingsInfo(user);
            return View(dto);
        }

        public IActionResult DeleteFromBookingsList(Guid id)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _bookingListService.deleteBookingFromShoppingCart(user, id); 
            return RedirectToAction("Index");
        }
        public IActionResult order()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _bookingListService.order(user);
            return RedirectToAction("Index");
        }
    }
}
