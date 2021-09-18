using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Data;
using Entities;
using Infrastructure.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Repositories
{
    public class TodoRepository:ITodoRepository
    {
        private readonly TodoDataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TodoRepository> _logger;
        
        public TodoRepository(IMapper mapper, TodoDataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<TodoDto>> GetTodos()
        {
            var todos = await _context.Todos.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<Todo>,IEnumerable<TodoDto>>(todos);
        }

        public async Task<TodoDto> GetTodo(int id)
        {
            Todo todo = await _context.Todos.FindAsync(id);
            
            _ = todo ?? throw new RestException(HttpStatusCode.NotFound,new {Todo = "Not Found"});
            
            return _mapper.Map<Todo,TodoDto>(todo);
        }

        public async Task<bool> CreateTodo(TodoFromUserDto todoDto)
        {
            Todo todo = _mapper.Map<TodoFromUserDto,Todo>(todoDto);
            await _context.Todos.AddAsync(todo);
            return  await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateTodo(int id,TodoFromUserDto todoDto)
        {
            Todo todo = await _context.Todos.FindAsync(id);

            _ = todo ?? throw new RestException(HttpStatusCode.NotFound, new { Todo = "Not found" });

            todo = _mapper.Map(todoDto, todo);
            _context.Todos.Update(todo);
            
            return  await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            Todo todo = await _context.Todos.FindAsync(id);

            _ = todo ?? throw new RestException(HttpStatusCode.NotFound, new { Todo = "Not found" });
            
            _context.Todos.Remove(todo);
            
            return  await _context.SaveChangesAsync() > 0;
        }
    }
}