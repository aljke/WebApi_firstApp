using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_firstApp.Models
{
    public interface IAuthorTodoRepository
    {
        void Add(AuthorTodo item);
        IEnumerable<AuthorTodo> GetAll();
        void Remove(long key);
        void Update(AuthorTodo item);
        AuthorTodo Find(long key);
    }
}
