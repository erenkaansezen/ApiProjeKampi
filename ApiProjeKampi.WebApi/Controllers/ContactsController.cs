using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto contactDto)
        {
            var contact = new Contact
            {
                MapLocation = contactDto.MapLocation,
                Adress = contactDto.Adress,
                Phone = contactDto.Phone,
                Email = contactDto.Email,
                OpenHours = contactDto.OpenHours
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgileri başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi başarıyla silindi");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            return Ok(contact);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDto.ContactId;
            contact.Email = updateContactDto.Email;
            contact.Adress = updateContactDto.Adress;
            contact.Phone = updateContactDto.Phone;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpenHours = updateContactDto.OpenHours;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgileri başarıyla güncellendi");

        }


    }
}
