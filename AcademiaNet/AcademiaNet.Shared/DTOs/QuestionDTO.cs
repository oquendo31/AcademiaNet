using AcademiaNet.Shared.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QuestionDTO
{
    [Key]
    public int QuestionID { get; set; }

    [MaxLength(100)]
    [Required]
    public string Text { get; set; } = null!;

    public ICollection<Exam>? Exams { get; set; }

    public int ExamsCount => Exams == null ? 0 : Exams.Count;

    public List<AnswerDTO> Answers { get; set; } = new();
}