using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaNet.Shared.Entites
{
    public class ExamResult
    {
        [Key]
        public int ExamResultID { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public int UserID { get; set; }

        public User User { get; set; } = null!;

        [Required]
        public int ExamID { get; set; }

        public Exam Exam { get; set; } = null!;
    }
}