using System.Collections.Generic;
using AutoMapper;
using CodeDeckAPI.Data;
using CodeDeckAPI.Dtos;
using CodeDeckAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CodeDeckAPI.Controllers
{
    [Authorize]
    // /api/CodeDeck
    [ApiController]
    [Route("api/CodeDeck")]
    public class CodeCardController : ControllerBase
    {
        private readonly ICodeCardRepo _repo;
        private readonly IMapper _mapper;

        public CodeCardController(ICodeCardRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        // GET /api/CodeDeck
        [HttpGet]
        public ActionResult <IEnumerable<CodeCardReadDto>> GetAllCards()
        {
            var cardItems = _repo.GetAllCards();

            return Ok(_mapper.Map<IEnumerable<CodeCardReadDto>>(cardItems));
        }

        [AllowAnonymous]
        // GET /api/CodeDeck/{id}
        [HttpGet("{id}", Name = "GetCodeCardById")]
        public ActionResult <CodeCardReadDto> GetCodeCardById(int id)
        {
            var cardItem = _repo.GetCodeCardById(id);

            if(cardItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CodeCardReadDto>(cardItem));
        }

        [Authorize(Roles = Role.Admin)]
        // POST /api/CodeDeck
        [HttpPost]
        public ActionResult<CodeCardReadDto> CreateCodeCard(CodeCardCreateDto codeCardCreateDto)
        {
            var codeCardModel = _mapper.Map<CodeCard>(codeCardCreateDto);
            _repo.CreateCodeCard(codeCardModel);
            _repo.SaveChanges();

            var codeCardReadDto = _mapper.Map<CodeCardReadDto>(codeCardModel);

            return CreatedAtRoute(nameof(GetCodeCardById), new { CardId = codeCardReadDto.CardId}, codeCardReadDto);
        }

        [Authorize(Roles = Role.Admin)]
        // PUT /api/CodeDeck/{id} Full Update of Item
        [HttpPut("{id}")]
        public ActionResult UpdateCodeCard(int id, CodeCardUpdateDto codeCardUpdateDto)
        {
            var codeCardModelFromRepo = _repo.GetCodeCardById(id);
            if(codeCardModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(codeCardUpdateDto, codeCardModelFromRepo);
            _repo.UpdateCodeCard(codeCardModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        [Authorize(Roles = Role.Admin)]
        // PATCH /api/CodeDeck/{id} Partial Update of Item
        [HttpPatch("{id}")]
        public ActionResult PartialCodeCardUpdate(int id, JsonPatchDocument<CodeCardUpdateDto> patchDoc)
        {
            var codeCardModelFromRepo = _repo.GetCodeCardById(id);
            if(codeCardModelFromRepo == null)
            {
                return NotFound();
            }

            var codeCardToPatch = _mapper.Map<CodeCardUpdateDto>(codeCardModelFromRepo);
            patchDoc.ApplyTo(codeCardToPatch, ModelState);

            if(!TryValidateModel(codeCardToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(codeCardToPatch, codeCardModelFromRepo);
            _repo.UpdateCodeCard(codeCardModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}