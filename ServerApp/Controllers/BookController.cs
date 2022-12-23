using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public BookController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("[action]")]
        public IList<Book> GetList()
        {
            return _dataContext.Books.ToArray();
        }

        [HttpPost("[action]")]
        public void Add(Book book)
        {
            _dataContext.Books.Add(book);

            _dataContext.SaveChanges();
        }

        [HttpPost("[action]")]
        public void Update(Book book)
        {
            _dataContext.Update(book);

            _dataContext.SaveChanges();
        }

        [HttpPost("[action]")]
        public void Delete(int id)
        {
            _dataContext.Books.RemoveRange(_dataContext.Books.Where(x => x.Id == id));

            _dataContext.SaveChanges();
        }
    }
}