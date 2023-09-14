using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreRelations.Entities
{
    //public class EFCoreDbContext : DbContext
    //{
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        //To Display the Generated the Database Script
    //        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    //        //Configuring the Connection String
    //        optionsBuilder.UseSqlServer(@"Server=NIT-LPT-R339;Database=EFCoreDb3;Trusted_Connection=True;TrustServerCertificate=True;");
    //    }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        // // Configure One to One Relationships Between Student and Address
    //        // modelBuilder.Entity<Student>()
    //        //.HasOne(s => s.Address) //Student has one Address
    //        //.WithOne(ad => ad.Student) //Address is associated with one Student
    //        //.HasForeignKey<Address>(ad => ad.AddressId) //Foreign key in Address table
    //        //.IsRequired(); //This is a required relationship.

    //            modelBuilder.Entity<Address>()
    //         .HasOne(ad => ad.Student) //Address has one Student Navigation Entity
    //         .WithOne(std => std.Address) //Student is associated with one Address
    //         .HasForeignKey<Student>(std => std.StudentId) //Foreign key in Student table
    //         .IsRequired(true); //This is a required relationship.
    //        //Creating an Instance of the Context Class
    //        using EFCoreDbContext context = new EFCoreDbContext();
    //        //Creating Address Entity, 
    //        var studentAddress = new Address() { AddressLine1 = "Text1", AddressLine2 = "Text2" };
    //        //Creating Student Entity, configuring the Related Student Address Entity
    //        var student = new Student() { FirstName = "Pranaya", LastName = "Rout", Address = studentAddress };
    //        context.Students.Add(student);
    //        context.SaveChanges();
    //        Console.WriteLine("Student and Address Added");
    //        Console.ReadKey();


    //    }
    //    public DbSet<Student> Students { get; set; }
    //    public DbSet<Address> Addresses { get; set; }
    //}

    //public class EFCoreDbContext : DbContext
    //{
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        //Configuring the Connection String
    //        optionsBuilder.UseSqlServer(@"Server=NIT-LPT-R339;Database=EFCoreDb3;Trusted_Connection=True;TrustServerCertificate=True;");
    //    }
    ////protected override void OnModelCreating(ModelBuilder modelBuilder)
    ////{
    ////    // Configure One to Many Relationships Between Author and Book
    ////    modelBuilder.Entity<Author>()
    ////    .HasMany(a => a.Books) // Author has many Books
    ////    .WithOne(b => b.Author) // Book is associated with one Author
    ////    .HasForeignKey(b => b.AuthorId) // AuthorId is the Foreign key in Book table
    ////    .IsRequired(); //This is a Required Relationship
    ////}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Configure One to Many Relationships Between Author and Book
    //    modelBuilder.Entity<Author>()
    //    .HasMany(a => a.Books) // Author has many Books
    //    .WithOne(b => b.Author) // Book is associated with one Author
    //    .HasForeignKey(b => b.AuthorId) // AuthorId is the Foreign key in Book table
    //    .IsRequired()
    //    .OnDelete(DeleteBehavior.Cascade); ; //This is a Required Relationship
    //}
    //public DbSet<Author> Authors { get; set; }
    //    public DbSet<Book> Books { get; set; }
    //}
    public class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=NIT-LPT-R339;Database=EFCoreDb5;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses) // Student can enroll in many Courses
                .WithMany(e => e.Students) // Course can have many Students

                // Define the joining table
                .UsingEntity<StudentCourse>(
                    //navigations needs to be configured explicitly 
                    l => l.HasOne<Course>(e => e.Course).WithMany(e => e.StudentCourses), //MapLeftKey
                    r => r.HasOne<Student>(e => e.Student).WithMany(e => e.StudentCourses)); //MapRightKey
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
