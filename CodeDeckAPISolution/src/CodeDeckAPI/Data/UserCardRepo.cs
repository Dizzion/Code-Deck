// using System;
// using System.Threading.Tasks;
// using AutoMapper;
// using CodeDeckAPI.Dtos;
// using CodeDeckAPI.Models;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;

// namespace CodeDeckAPI.Data
// {
//     public class UserCardRepo : IUserCardRepo
//     {
//         private readonly CodeCardContext _context;
//         private readonly IHttpContextAccessor _httpContext;
//         private readonly IMapper _mapper;
//         public UserCardRepo(CodeCardContext context, IHttpContextAccessor httpContext, IMapper mapper)
//         {
//             _mapper = mapper;
//             _httpContext = httpContext;
//             _context = context;

//         }
//         public async Task<ServiceResponse<UserReadDto>> AddUserCard(UserCardCreateDto userCardCreateDto)
//         {
//             ServiceResponse<UserReadDto> response = new ServiceResponse<UserReadDto>();
//             try
//             {
//                 User user = await _context.Users
//                     .Include(c => c.UserCards)
//                     .FirstOrDefaultAsync(u => u.UserId == userCardCreateDto.UserId);
//             }
//             catch (Exception ex)
//             {
//                 response.Success = false;
//                 response.Message = ex.Message;
//             }
//             return response;
//         }
//     }
// }