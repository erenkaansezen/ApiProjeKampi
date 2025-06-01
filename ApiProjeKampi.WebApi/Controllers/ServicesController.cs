using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var services = _context.Services.ToList();
            return Ok(services);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Servis ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return Ok("Servis silme işlemi başarılı");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetService(int id)
        {
            var service = _context.Services.Find(id);
            return Ok(service);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Servis Güncelleme İşlemi Başarılı");
        }
    }
}
