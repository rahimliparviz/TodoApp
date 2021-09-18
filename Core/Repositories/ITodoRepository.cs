using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTOs;


namespace Core.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoDto>> GetTodos();
        Task<TodoDto> GetTodo(int id);
        Task<bool> CreateTodo(TodoFromUserDto todo);
        Task<bool> UpdateTodo(int id,TodoFromUserDto todo);
        Task<bool> DeleteTodo(int id);
    }
}