using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
            
        private readonly ApiContext _context;
        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var Testimonial = _context.Testimonials.ToList();
            return Ok(Testimonial);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Servis ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return Ok("Servis silme işlemi başarılı");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetService(int id)
        {
            var service = _context.Testimonials.Find(id);
            return Ok(service);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonials)
        {
            _context.Testimonials.Update(testimonials);
            _context.SaveChanges();
            return Ok("Servis Güncelleme İşlemi Başarılı");
        }
    }
}
