using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApiContext _context;
        public EventController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EventList()
        {
            var Events = _context.Events.ToList();
            return Ok(Events);
        }

        [HttpPost]
        public IActionResult CreateEvent(Event events)
        {
            _context.Events.Add(events);
            _context.SaveChanges();
            return Ok("Etkinlik ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteEvent(int id)
        {
            var category = _context.Events.Find(id);
            _context.Events.Remove(category);
            return Ok("Etkinlik silme işlemi başarılı");
        }

        [HttpGet("GetEvent")]
        public IActionResult GetEvent(int id)
        {
            var category = _context.Events.Find(id);
            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateEvent(Event events)
        {
            _context.Events.Update(events);
            _context.SaveChanges();
            return Ok("Etkinlik Güncelleme İşlemi Başarılı");
        }
    }
}
