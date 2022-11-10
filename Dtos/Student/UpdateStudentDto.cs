using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_rpg.Models;

namespace Student_rpg.Dtos.Student
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime DoB { get; set; }
        public EducationLevel EducateLevel { get; set; }
        public string? Specialization { get; set; }
        public string? UniName { get; set; }
    }
}