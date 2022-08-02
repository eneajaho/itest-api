using System.ComponentModel.DataAnnotations;

namespace iTestApi.Entities;

public class Question
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    
    public QuestionDifficulty Difficulty { get; set; } = QuestionDifficulty.Easy;

    public List<Answer> Answers { get; set; } = new();
    public string CorrectAnswer { get; set; } = "";
    
    public DateTime CreatedAt { get; set; } = new();
}


public class Answer
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
}