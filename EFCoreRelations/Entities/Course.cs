using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelations.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        //One Course Can be Taken by Many Students
        public List<Student> Students { get; set; } = new();
        //StudentCourses Collection Property for Implementing Many to Many Relationship
        public List<StudentCourse> StudentCourses { get; set; } = new();
    }
}
