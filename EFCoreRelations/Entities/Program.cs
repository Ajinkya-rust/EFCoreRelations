using Microsoft.EntityFrameworkCore;
namespace EFCoreRelations.Entities
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            //Creating an Instance of the Context Class
    //            using EFCoreDbContext context = new EFCoreDbContext();
    //            //Creating Address Entity, 
    //            var studentAddress = new Address() { AddressLine1 = "Text1", AddressLine2 = "Text2" };
    //            //Creating Student Entity, configuring the Related Student Address Entity
    //            var student = new Student() { FirstName = "Pranaya", LastName = "Rout", Address = studentAddress };
    //            context.Students.Add(student);
    //            context.SaveChanges();
    //            Console.WriteLine("Student and Address Added");
    //            Console.ReadKey();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error: {ex.Message}"); ;
    //        }
    //    }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            using var context = new EFCoreDbContext();
    //            //First Create Book Collection
    //            var books = new List<Book>
    //            {
    //                new Book() { Title = "C#" },
    //                new Book() { Title = "LINQ" },
    //                new Book() { Title = "ASP.NET Core" }
    //            };
    //            //Create an Instance of Author and Assign the books collection
    //            var author = new Author() { Name = "Pranaya", Books = books };
    //            context.Authors.Add(author);
    //            context.SaveChanges();

    //            Console.WriteLine("Author and Books Added");
    //            Console.ReadKey();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error: {ex.Message}"); ;
    //        }
    //    }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            using var context = new EFCoreDbContext();
    //            Author? Id1 = context.Authors.Find(1);
    //            if (Id1 != null)
    //            {
    //                context.Remove(Id1);
    //                context.SaveChanges();
    //                Console.WriteLine("Author Deleted");
    //            }
    //            else
    //            {
    //                Console.WriteLine("Author Not Exists");
    //            }
    //            Console.ReadKey();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error: {ex.Message}"); ;
    //        }
    //    }
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Creating an Instance of Context Class
                using var context = new EFCoreDbContext();
                //Creating List of Courses
                var courses = new List<Course>
                {
                    new Course() { CourseName = "EF Core", Description="It is an ORM Tool"},
                    new Course() { CourseName = "ASP.NET Core", Description ="Open-Source & Cross-Platform" }
                };
                context.Courses.AddRange(courses);
                context.SaveChanges();
                Console.WriteLine("Courses Added");
                //Creating an Instance of Student Class
                var Pranaya = new Student() { Name = "Pranaya", Courses = courses };
                context.Students.Add(Pranaya);
                var Hina = new Student() { Name = "Hina", Courses = courses };
                context.Students.Add(Hina);
                context.SaveChanges();
                Console.WriteLine("Students Added");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }
        }
    }
}