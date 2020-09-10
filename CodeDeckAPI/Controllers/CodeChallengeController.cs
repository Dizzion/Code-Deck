using System.Collections.Generic;
using AutoMapper;
using CodeDeckAPI.Data;
using CodeDeckAPI.Models;
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
        public ActionResult <IEnumerable<CodeChallenge>> GetAllChallenges()
        {
            var challengeItems = _repo.GetAllChallenges();

            return Ok(challengeItems);
        }

        // GET /api/CodeDeck/{id}
        [HttpGet("{id}")]
        public ActionResult <CodeChallenge> getChallengeById(int id)
        {
            var challengeItem = _repo.GetCodeChallengeById(id);

            return Ok(challengeItem);
        }
    }
}