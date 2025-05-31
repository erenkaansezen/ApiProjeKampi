using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var messages = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Mesaj başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return Ok("Mesaj başarıyla silindi");
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var message = _context.Messages.Find(id);
            return Ok(_mapper.Map<ResultMessageDto>(message));
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Mesaj güncelleme işlemi başarılı");
        }
    }
}
