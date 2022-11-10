using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Student_rpg.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DoB { get; set; }
        [Required]
        public EducationLevel EducateLevel { get; set; }
        public string? Specialization { get; set; }
        public string? UniName { get; set; }
        public User? User { get; set; }
    }
}