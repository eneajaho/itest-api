using AutoMapper;
using iTestApi.DTOs.Question;
using iTestApi.Entities;
using iTestApi.Entities.Core;
using iTestApi.Helpers;
using iTestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace iTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly QuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionsController(DataContext context, QuestionService questionService, IMapper mapper)
        {
            _context = context;
            _questionService = questionService;
            _mapper = mapper;
        }

        // GET: api/questions
        [HttpGet]
        public async Task<PagedData<QuestionDto>> GetQuestions([FromQuery] GetQuestionsParams questionsParams) =>
            await _questionService.GetQuestionsAsync(questionsParams);

        [HttpGet("difficulties")]
        public List<KeyValue> GetDifficulties()
        {
            return new List<KeyValue>
            {
                new() { Key = 0, Value = "Easy" },
                new() { Key = 1, Value = "Medium" },
                new() { Key = 2, Value = "High" }
            };
        }


        // GET: api/question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
        {
            var package = await _questionService.QuestionByIdAsync(id);
        
            if (package == null)
                return NotFound();
        
            return package;
        }

        // PUT: api/questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [AuthorizedRoles(Role.Admin)]
        public async Task<ActionResult<QuestionDto>> PutQuestion(int id, QuestionUpdateDto questionUpdateDto)
        {
            if (id != questionUpdateDto.Id)
                return BadRequest();
        
            var question = await _questionService.GetByIdAsync(id);
        
            if (question == null)
                return NotFound();

            _mapper.Map(questionUpdateDto, question);
        
            await _context.SaveChangesAsync();
            
            return _mapper.Map<QuestionDto>(question);
        }

        // POST: api/questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        // [AuthorizedRoles(Role.Admin)]
        public async Task<ActionResult<QuestionDto>> CreateQuestion(QuestionCreateDto questionCreateDto)
        {
            var questionToCreate = _mapper.Map<Question>(questionCreateDto);

            await _context.AddAsync(questionToCreate);
            await _context.SaveChangesAsync();

            var packageForReturn = _mapper.Map<QuestionDto>(questionToCreate);

            return packageForReturn;
        }

        // DELETE: api/Package/5
        // [HttpDelete("{id}")]
        // // [AuthorizedRoles(Role.Admin)]
        // public async Task<IActionResult> DeletePackage(int id)
        // {
        //     var user = await _context.Packages.FindAsync(id);
        //
        //     if (user == null)
        //         return NotFound();
        //
        //     _context.Packages.Remove(user);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }

        // GET: api/Package/5
        // [HttpGet("user/{userId}")]
        // public async Task<IEnumerable<PackageDto>?> GetUserPackage(int userId) =>
        //     await _packageService.GetPackagesByUserId(userId);
    }
}