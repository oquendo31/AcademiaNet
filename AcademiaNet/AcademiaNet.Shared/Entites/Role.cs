using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaNet.Shared.Entites
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; } // Permitir null

        public ICollection<User>? Users { get; set; }
        public int UsersCount => Users == null ? 0 : Users.Count;
    }
}