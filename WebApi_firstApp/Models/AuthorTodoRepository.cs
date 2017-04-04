using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_firstApp.Models
{
    public class AuthorTodoRepository : IAuthorTodoRepository
    {
        private readonly TodoContext _context;

        public AuthorTodoRepository(TodoContext context)
        {
            _context = context;

            if(_context.Authors.Count() == 0)
                _context.Authors.Add(new AuthorTodo { Name = "Author 1"});
        }

        public void Add(AuthorTodo item)
        {
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        public AuthorTodo Find(long key)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == key);
        }

        public IEnumerable<AuthorTodo> GetAll()
        {
            return _context.Authors.ToList();
        }

        public void Remove(long key)
        {
            var entity = _context.Authors.First(x => x.Id == key);
            _context.Authors.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(AuthorTodo item)
        {
            _context.Authors.Update(item);
            _context.SaveChanges();
        }
    }
}
