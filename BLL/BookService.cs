using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BookService
    {
        private readonly PruebaContext _context;
        public BookService(PruebaContext context)
        {
            _context = context;
        }

        public ProductoLogResponse Save(Book producto)
        {
            try
            {
                if (_context.Books.Find(producto.CodBook) == null)
                {
                    _context.Books.Add(producto);
                    _context.SaveChanges();
                    return new ProductoLogResponse(producto);
                }
                return new ProductoLogResponse($"El libro ya se encuentra registrado");
            }
            catch (Exception e) { return new ProductoLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public ProductoLogResponse Update(int codBooks, Book book)
        {
            try
            {
                Book bookEncontrado = _context.Books.Find(codBooks);
                if (bookEncontrado != null)
                {
                    bookEncontrado.Author = book.Author;
                    bookEncontrado.Title = book.Title;
                    bookEncontrado.Publisher = book.Publisher;
                    bookEncontrado.Price = book.Price;
                    bookEncontrado.Genere = book.Genere;
                    _context.Books.Update(bookEncontrado);
                    _context.SaveChanges();
                    return new ProductoLogResponse(bookEncontrado);
                }
                return new ProductoLogResponse($"No se encuentra registro a modificar");
            }
            catch (Exception e) { return new ProductoLogResponse($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }

        public ProductoLogResponse Find(int codBooks)
        {
            try
            {
                Book producto = _context.Books.Find(codBooks);
                if (producto != null)
                {
                    return new ProductoLogResponse(producto);
                }
                return new ProductoLogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new ProductoLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete(int referencia)
        {
            try
            {
                Book book = _context.Books.Find(referencia);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                    return "Producto eliminado satisfactoriamente";
                }
                return ($"No se encuentra el producto a eliminar");
            }
            catch (Exception e) { return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
        }

        public ProductoConsultaResponse Consult()
        {
            try
            {
                List<Book> books = _context.Books.ToList();
                if (books != null)
                {
                    return new ProductoConsultaResponse(books);
                }
                return new ProductoConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new ProductoConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class ProductoLogResponse
    {
        public Book Book { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ProductoLogResponse(Book book)
        {
            Book = book;
            Error = false;
        }

        public ProductoLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ProductoConsultaResponse
    {
        public List<Book> Books { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ProductoConsultaResponse(List<Book> books)
        {
            Books = books;
            Error = false;
        }
        public ProductoConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}

