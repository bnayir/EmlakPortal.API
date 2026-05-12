using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;
using EmlakPortal.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly GenericRepository<Message> _repository;

        public MessagesController(GenericRepository<Message> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDTO dto)
        {
            var senderId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(senderId))
                return Unauthorized();
            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = dto.ReceiverId,
                PropertyId = dto.PropertyId,
                Text = dto.Text,
                SendDate = DateTime.Now
            };

            await _repository.AddAsync(message);
            return Ok("Mesajınız Başarıyla İletildi.");
        }

        [HttpGet("Inbox")]
        public async Task<IActionResult>  GetInbox()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var allMessages = await _repository.GetAllAsync();
            var inbox = allMessages.Where(m => m.ReceiverId == userId)
                                   .Select(m => new { m.MessageId, m.SenderId, m.PropertyId, m.Text, m.SendDate })
                                   .OrderByDescending(m => m.SendDate).ToList();
            return Ok(inbox);


        }

        [HttpGet("Outbox")]
        public async Task<IActionResult> GetOutbox()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var allMessages = await _repository.GetAllAsync();
            var outbox = allMessages.Where(m => m.SenderId == userId)
                                   .Select(m => new { m.MessageId, m.ReceiverId, m.PropertyId, m.Text, m.SendDate })
                                   .OrderByDescending(m => m.SendDate).ToList();
            return Ok(outbox);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound("Silinecek mesaj bulunamadı.");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (message.ReceiverId != userId)
            {
                return Unauthorized("Sadece size gelen mesajları silebilirsiniz.");
            }

            await _repository.DeleteAsync(id);
            return Ok("Mesaj başarıyla silindi.");
        }
    }
}
