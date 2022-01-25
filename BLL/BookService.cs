using DAL;
using DAL.Implements;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BookService
    {
        private readonly ApplicationContext _context;
        private readonly BookRepository _repository;
        public BookService(ApplicationContext context)
        {
            _context = context;
            _repository = new BookRepository(_context);
        }

        public BookLogResponse Save(Book book)
        {
            try
            {
                if (_repository.GetCod(book.CodBook).Result == null)
                {
                    _repository.Save(book);
                    return new BookLogResponse(book);
                }                
                return new BookLogResponse($"El libro ya se encuentra registrado");
            }
            catch (Exception e) { return new BookLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public BookLogResponse Update(int codBooks, Book book)
        {
            try
            { Book bookEncontrado = _repository.GetCod(codBooks).Result;
                if (bookEncontrado != null)
                {
                    bookEncontrado = book;
                    _repository.Update(bookEncontrado);                    
                    return new BookLogResponse(book);
                }
                return new BookLogResponse($"No se encuentra registro a modificar");
            }
            catch (Exception e) { return new BookLogResponse($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }

        public BookLogResponse Find(int codBooks)
        {
            try
            {
                Book book = _repository.GetCod(codBooks).Result;
                if (book != null)
                {
                    return new BookLogResponse(book);
                }
                return new BookLogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new BookLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete(int codBook)
        {
            try
            {
                Book book = _repository.GetCod(codBook).Result;
                if (book != null)
                {
                    _repository.Delete(book);
                    return "Libro eliminado satisfactoriamente";
                }
                return ($"No se encuentra el Libro a eliminar");
            }
            catch (Exception e) { return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
        }

        public BookConsultaResponse Consult()
        {
            try
            {
                List<Book> books = (List<Book>)_repository.Consult().Result;
                if (books != null)
                {
                    return new BookConsultaResponse(books);
                }
                return new BookConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new BookConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class BookLogResponse
    {
        public Book Book { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BookLogResponse(Book book)
        {
            Book = book;
            Error = false;
        }

        public BookLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class BookConsultaResponse
    {
        public List<Book> Books { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public BookConsultaResponse(List<Book> books)
        {
            Books = books;
            Error = false;
        }
        public BookConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}

