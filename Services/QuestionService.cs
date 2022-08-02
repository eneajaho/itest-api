using AutoMapper;
using AutoMapper.QueryableExtensions;
using iTestApi.DTOs.Question;
using iTestApi.Entities;
using iTestApi.Entities.Core;
using iTestApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace iTestApi.Services
{
    public class QuestionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
    
        public QuestionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        public async Task<PagedData<QuestionDto>> GetQuestionsAsync(GetQuestionsParams questionsParams)
        {
            var query = _context.Questions
                // we directly map to PackageDto so we don't query data we don't use
                .Include(x => x.Answers)
                .ProjectTo<QuestionDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
        
            if (!string.IsNullOrEmpty(questionsParams.Title))
                query = query.Where(x => x.Title.Contains(questionsParams.Title));
            
            if (!string.IsNullOrEmpty(questionsParams.Category))
                query = query.Where(x => x.Category.Equals(questionsParams.Category));

            if (questionsParams.Difficulty != null)
                query = query.Where(x => x.Difficulty.Equals(questionsParams.Difficulty));

            // if (packagesParams.UserId != null)
            //     query = query.Where(x => x.User.Id == packagesParams.UserId);
    
            // packages inherits from PaginationParams
            return await PagedData<QuestionDto>.CreateAsync(query, questionsParams);
        }
        //
        // public async Task<IEnumerable<PackageDto>?> GetPackagesByUserId(int userId) =>
        //     await _context.Packages
        //         .Where(u => u.UserId == userId)
        //         .ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
        //         .IgnoreAutoIncludes()
        //         .ToListAsync();
        //
        
        // Will be used when we need the whole Package entity (ex. on edit)
        public async Task<Question?> GetByIdAsync(int id) =>
            await _context.Questions
                .SingleOrDefaultAsync(u => u.Id == id);
        
        public async Task<QuestionDto?> QuestionByIdAsync(int id) =>
            await _context.Questions
                .Include(x => x.Answers)
                .ProjectTo<QuestionDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(u => u.Id == id);
    }
}