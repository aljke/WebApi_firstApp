using System.Collections.Generic;

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
