using AcademiaNet.Shared.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AnswerDTO
{
    [Key]
    public int AnswerID { get; set; }

    [MaxLength(100)]
    [Required]
    public string Text { get; set; } = null!;

    public bool IsCorrect { get; set; }
}