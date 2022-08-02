using System.ComponentModel.DataAnnotations;
using iTestApi.Entities;

namespace iTestApi.DTOs.Question
{
    public class QuestionCreateDto
    {
        [Required]
        public string Title { get; set; } = "";
        
        [Required]
        public string Category { get; set; } = "";
    
        public QuestionDifficulty Difficulty { get; set; } = QuestionDifficulty.Easy;

        [Required]
        [MaxLength(6)]
        public List<AnswerDto> Answers { get; set; } = new();
        
        [Required]
        public string CorrectAnswer { get; set; } = "";
    }
}