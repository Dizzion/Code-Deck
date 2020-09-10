using AutoMapper;
using CodeDeckAPI.Dtos;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Profiles
{
    public class CodeChallengeProfile : Profile
    {
        public CodeChallengeProfile()
        {
            // Source => Target
            CreateMap<CodeChallenge, CodeChallengeReadDto>();
            CreateMap<CodeChallengeCreateDto, CodeChallenge>();
            CreateMap<CodeChallengeUpdateDto, CodeChallenge>();
            CreateMap<CodeChallenge, CodeChallengeUpdateDto>();
        }
    }
}