using BLL.Interface;
using BLL.Response;
using BLL.Service;
using DAL;
using DAL.Implements;
using DAL.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class BookService : GenericService<Book>, IBookService
    {
        public BookService(ApplicationContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}

