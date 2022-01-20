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
        private BookService _service;
        private readonly IHubContext<SignalHub> _hubContext;

        public BookController(PruebaContext contex, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new BookService(contex);

        }

        [HttpPost]
        public async Task<ActionResult<Book>> GuardarAsync(BookInputModel bookInput)
        {
            var producto = mapearBook(bookInput);
            var request = _service.Save(producto);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Producto", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", bookInput);
            return Ok(request.Book);
        }

        private Book mapearBook(BookInputModel bookInput)
        {
            var book = new Book();

            book.Title = bookInput.Title;
            book.Publisher = bookInput.Publisher;
            book.Price = bookInput.Price;
            book.Author = bookInput.Author;
            book.Genere = bookInput.Genere;
            return book;
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
