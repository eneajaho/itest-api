using iTestApi.Entities;

namespace iTestApi.DTOs.Question;

public class QuestionDto
{
    public int Id { get; set; }
    
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    
    public QuestionDifficulty Difficulty { get; set; } = QuestionDifficulty.Easy;

    public List<AnswerDto> Answers { get; set; } = new();
    public string CorrectAnswer { get; set; } = "";
    
    public DateTime CreatedAt { get; set; } = new();
}