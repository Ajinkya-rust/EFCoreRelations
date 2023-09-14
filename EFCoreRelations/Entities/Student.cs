using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelations.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        //One Student Can have Many Courses
        public List<Course> Courses { get; set; } = new();
        //StudentCourses Collection Property for Implementing Many to Many Relationship
        public List<StudentCourse> StudentCourses { get; set; } = new();
    }
}

