using AutoMapper;
using Core.DTOs;
using Entities;

namespace Core.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<TodoFromUserDto, Todo>();

        }
    }
}