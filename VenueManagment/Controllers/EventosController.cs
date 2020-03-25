using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VenueManagment.Library;
using VenueManagment.Models;
using Microsoft.Extensions.Options;
using VenueManagment.DataAccessLayer;
using System.Diagnostics;


namespace VenueManagment.Controllers
{
    public class EventosController : Controller
    {
        private readonly DbContexto _context;


        //public EventosController(DbContexto context)
        //{
        //    _context = context;
        //}
        

        public IActionResult Index()
        {
            return View();
        }
        private DA _DA { get; set; }

        public EventosController(IOptions<AppSettings> settings)
        {
            _DA = new DA(settings.Value.ConnectionStr);
        }

        [HttpGet]
            public IActionResult GetCalendarEvents(string fechaInicio, string fechaFin)
            {
                List<Evento> events = _DA.GetCalendarEvents(fechaInicio, fechaFin);

                return Json(events);
            }

            [HttpPost]
            public IActionResult UpdateEvent([FromBody] Evento evt)
            {
                string message = String.Empty;

                message = _DA.UpdateEvent(evt);

                return Json(new { message });
            }

            [HttpPost]
            public IActionResult AddEvent([FromBody] Evento evt)
            {
                string message = String.Empty;
                int idEvento = 0;

                message = _DA.AddEvent(evt, out idEvento);

                return Json(new { message, idEvento });
            }

            [HttpPost]
            public IActionResult DeleteEvent([FromBody] Evento evt)
            {
                string message = String.Empty;

                message = _DA.DeleteEvent(evt.idEvento);

                return Json(new { message });
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        

    }
}
