using System.Collections.Generic;
using AutoMapper;
using CodeDeckAPI.Data;
using CodeDeckAPI.Dtos;
using CodeDeckAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CodeDeckAPI.Controllers
{
    // /api/CodeDeck
    [ApiController]
    [Route("api/CodeDeck")]
    public class CodeChallengeController : ControllerBase
    {
        private readonly ICodeChallengeRepo _repo;
        private readonly IMapper _mapper;

        public CodeChallengeController(ICodeChallengeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET /api/CodeDeck
        [HttpGet]
        public ActionResult <IEnumerable<CodeChallengeReadDto>> GetAllChallenges()
        {
            var challengeItems = _repo.GetAllChallenges();

            return Ok(_mapper.Map<IEnumerable<CodeChallengeReadDto>>(challengeItems));
        }

        // GET /api/CodeDeck/{id}
        [HttpGet("{id}", Name="GetCodeChallengeById")]
        public ActionResult <CodeChallengeReadDto> GetCodeChallengeById(int id)
        {
            var challengeItem = _repo.GetCodeChallengeById(id);

            if(challengeItem != null)
            {
                return Ok(challengeItem);
            }
            return NotFound();
        }

        // POST /api/CodeDeck
        [HttpPost]
        public ActionResult <CodeChallengeReadDto> CreateCodeChallenge(CodeChallengeCreateDto codeChallengeCreateDto)
        {
            var codeChallengeModel = _mapper.Map<CodeChallenge>(codeChallengeCreateDto);
            _repo.CreateCodeChallenge(codeChallengeModel);
            _repo.SaveChanges();

            var codeChallengeReadDto = _mapper.Map<CodeChallengeReadDto>(codeChallengeModel);

            return CreatedAtRoute(nameof(GetCodeChallengeById), new {Id = codeChallengeReadDto.Id}, codeChallengeReadDto);
        }

        // PUT /api/CodeDeck/{id} Full Update of Item
        [HttpPut("{id}")]
        public ActionResult UpdateCodeChallenge(int id, CodeChallengeUpdateDto codeChallengeUpdateDto)
        {
            var codeChallengeModelFromRepo = _repo.GetCodeChallengeById(id);
            if(codeChallengeModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(codeChallengeUpdateDto, codeChallengeModelFromRepo);
            _repo.UpdateCodeChallenge(codeChallengeModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        // PATCH /api/CodeDeck/{id} Partial Update of Item
        [HttpPatch("{id}")]
        public ActionResult PartialCodeChallengeUpdate(int id, JsonPatchDocument<CodeChallengeUpdateDto> patchDoc)
        {
            var codeChallengeModelFromRepo = _repo.GetCodeChallengeById(id);
            if(codeChallengeModelFromRepo == null)
            {
                return NotFound();
            }

            var codeChallengeToPatch = _mapper.Map<CodeChallengeUpdateDto>(codeChallengeModelFromRepo);
            patchDoc.ApplyTo(codeChallengeToPatch, ModelState);

            if(!TryValidateModel(codeChallengeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(codeChallengeToPatch, codeChallengeModelFromRepo);
            _repo.UpdateCodeChallenge(codeChallengeModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}