using AutoMapper;
using CodeDeckAPI.Dtos;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Profiles
{
    public class CodeCardProfile : Profile
    {
        public CodeCardProfile()
        {
            // Source => Target
            CreateMap<CodeCard, CodeCardReadDto>();
            CreateMap<CodeCardCreateDto, CodeCard>();
            CreateMap<CodeCardUpdateDto, CodeCard>();
            CreateMap<CodeCard, CodeCardUpdateDto>();
            CreateMap<User, UserReadDto>();
        }
    }
}