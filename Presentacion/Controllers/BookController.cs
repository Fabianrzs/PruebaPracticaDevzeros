using AutoMapper;
using BLL;
using BLL.Interface;
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
        private readonly IBookService _service;
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly IMapper _mapper;
        public BookController(IHubContext<SignalHub> hubContext, IMapper mapper,
            IBookService service)
        {
            _hubContext = hubContext;
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Book> GuardarAsync(BookInputModel bookInput)
        {
            var request = _service.Save(_mapper.Map<Book>(bookInput));
            return request.Error ? BadRequest(request.Mensaje) : Ok(request.Entity);
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
            var request = _service.Delete(codBook);
            return Ok(request);
        }

        [HttpPut("{codBook}")]
        public ActionResult<Book> Put(int codBook, Book book)
        {
            var request = _service.Update(codBook,book);
            return request.Error ? BadRequest(request.Mensaje) : Ok(request.Entity);
        }
    }
}
