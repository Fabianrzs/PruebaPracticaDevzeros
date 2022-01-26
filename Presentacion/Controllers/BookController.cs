using AutoMapper;
using BLL;
using BLL.Interface;
using DAL;
using DAL.Implements;
using DAL.UnitOfWork;
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
        private readonly IGenericService<Book> _service;
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly IMapper _mapper;
        public BookController(IHubContext<SignalHub> hubContext, IMapper mapper,
            IGenericService<Book> service)
        {
            _hubContext = hubContext;
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> GuardarAsync(BookInputModel bookInput)
        {
            var request = _service.SaveAsync(_mapper.Map<Book>(bookInput));
            if (request.Result.Error) return BadRequest(request.Result.Mensaje);
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", bookInput);
            return Ok(request.Result.Entity);
        }

        [HttpGet]
        public ActionResult<List<Book>> Consult()
        {
            var request = _service.Consult();
            return request.Error ? BadRequest(request.Mensaje) : Ok(request.Books);
        }

        [HttpGet("{codBook}")]
        public ActionResult<Book> Find(int codBook)
        {
            var request = _service.Find(codBook);
            return request.Error ? BadRequest(request.Mensaje) : Ok(request.Entity);
        }

        [HttpDelete("{codBook}")]
        public ActionResult<Book> Delete(int codBook)
        {
            var request = _service.DeleteAsync(codBook);
            return Ok(request.Result);
        }

        [HttpPut("{codBook}")]
        public ActionResult<Book> Put(int codBook, Book book)
        {
            var request = _service.UpdateAsync(codBook,book);
            return request.Result.Error ? BadRequest(request.Result.Mensaje) : Ok(request.Result.Entity);
        }
    }
}
