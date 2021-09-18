using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Todo
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        
    }
}