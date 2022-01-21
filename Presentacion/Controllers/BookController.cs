using AutoMapper;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentacion.Hubs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly IMapper _mapper;
        public BookController(ApplicationContext contex, IHubContext<SignalHub> hubContext, IMapper mapper)
        {
            _hubContext = hubContext;
            _service = new BookService(contex);
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> GuardarAsync(BookInputModel bookInput)
        {
            var request = _service.Save(_mapper.Map<Book>(bookInput));
            if (request.Error) return BadRequest(request.Mensaje);
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", bookInput);
            return Ok(request.Book);
        }

        [HttpGet]
        public ActionResult<List<Book>> Consult()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Books);
        }

        [HttpGet("{codBook}")]
        public ActionResult<Book> Find(int codBook)
        {
            var request = _service.Find(codBook);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Book);
        }

        [HttpDelete("{codBook}")]
        public ActionResult<Book> Delete(int codBook)
        {
            var request = _service.Delete(codBook);
            return Ok(request);
        }

        [HttpPut("{codBook}")]
        public ActionResult<Book> Put(int codBook, Book book)
        {
            var request = _service.Update( codBook, book);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Book);
        }
    }
}
