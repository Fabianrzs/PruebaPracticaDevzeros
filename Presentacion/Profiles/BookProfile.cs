using AutoMapper;
using Entity;

namespace Presentacion.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<BookInputModel, Book>();
        }
    }
}
