using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TodoDataContext:DbContext
    {
        public TodoDataContext(DbContextOptions opt) : base(opt) { }
        
        public DbSet<Todo> Todos { get; set; }
    }
}