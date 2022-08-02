using iTestApi.Entities;
using iTestApi.Helpers;

namespace iTestApi.DTOs.Question
{
    public class GetQuestionsParams : PaginationParams
    {
        public string? Title { get; set; }
        public string? Category { get; set; }
        public QuestionDifficulty? Difficulty { get; set; }
    }
}