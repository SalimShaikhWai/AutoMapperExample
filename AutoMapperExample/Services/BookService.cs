using AutoMapperExample.Interface;
using AutoMapperExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperExample.Services
{
    public class BookService: ICrudInterface<Book>
    {
        private readonly UserMgtContext _userMgtContext;

        public BookService(UserMgtContext userMgtContext)
        {
            _userMgtContext = userMgtContext;
        }

        public async Task CreateAsync(Book entity)
        {
          await  _userMgtContext.AddAsync(entity);
          await  _userMgtContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book =await _userMgtContext.Books.SingleAsync(x => x.Id == id);
             _userMgtContext.Books.Remove(book);
          
        }

        public async Task<List<Book>> GetAllAsync()
        {
         var list= await _userMgtContext.Books.ToListAsync();
            return list;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _userMgtContext.Books.SingleOrDefaultAsync(b=>b.Id == id);
        }

        public Task Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
