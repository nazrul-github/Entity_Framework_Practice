using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QueriesUsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ProjectDbContext();

            /*   var context= new ProjectDbContext();

               //LINQ syntax

               var query =
                   from c in context.Course
                   where c.Name.Contains("C#")
                   orderby c.Name
                   select c;

               foreach (var name in query)
               {
                   Console.WriteLine(name.Name);
               }

               //Extension Methods
               var courses = context.Course
                   .Where(c => c.Name.Contains("C#"))
                   .OrderBy(c => c.Name);

               foreach (var course in courses)
               {
                   Console.WriteLine(course.Name);
               }

               Console.ReadKey();*/


            /*  var query = from c in context.Course where c.Level == 1 select c;

              // Order By -- order all course by their level
              var query2 = from c in context.Course orderby c.Level, c.Name descending , c.Name.Contains("c") select c;
              foreach (var VARIABLE in query2)
              {
                  Console.WriteLine(VARIABLE.Name);
              }*/

            //Projection
            /* var query3 = from a in context.Author
                 where a.Name.EndsWith("c")
                 orderby a.Id
                 select new {Name = a.Name, Author = a.Courses};*/

            //Group By
            /*   var query = from c in context.Course group c by c.Level into c select c;
               foreach (var group in query)
               {
                   Console.WriteLine(group.Key);

                   foreach (var course in group)
                   {
                       Console.WriteLine("\t{0}",course.Name);
                   }
               }*/


            //Extension Method

            //   var coursesInLevel1 = from c in context.Course where c.Level.Equals(1) select c;

            /*   var coursesInLevel1 = context.Course.Where(c => c.Level.Equals(1)).Select(c=>new {CourseName = c.Name, CourseAuthor = c.Author.Name});

               var allcourseAndThierAuthour = context.Course.Select(c => new
                   {CourseName = c.Name, CourseDescription = c.Description, CourseCover = c.Cover,CourseAuthor = c.Author.Name})
                   .OrderBy(c=>c.CourseName).ThenBy(c=>c.CourseAuthor);

               foreach (var course in allcourseAndThierAuthour)
               {
                   Console.WriteLine("{0} - {1} - {2} - {3} ",course.CourseName,course.CourseAuthor,course.CourseCover,course.CourseDescription);
               }
               */
            /*  var courses = context.Course.Where(c => c.Level == 1).OrderByDescending(c => c.Name)
                  .ThenByDescending(c => c.Level).Select(c => c.Tags);

              foreach (var tag in courses)
              {
                  foreach (var property in tag)
                  {
                      Console.WriteLine("Tag: {0} - Id: {1}", property.Name,property.Id);
                  }
              }*/
            /*  var tags = context.Course.Where(c => c.Level == 1).OrderByDescending(c => c.Name)
                  .ThenByDescending(c => c.Level).SelectMany(c => c.Tags);

              foreach (var tag in tags)
              {
                  Console.WriteLine("Tag: {0} - Id: {1}", tag.Name, tag.Id);
              }*/


            /*            var tags = context.Course.Where(c => c.Level == 1).OrderByDescending(c => c.Name)
                            .ThenByDescending(c => c.Level).SelectMany(c => c.Tags).Distinct().Count();

                        Console.WriteLine(tags);*/

            /*  var groups = context.Course.GroupBy(c => c.Level);
              foreach (var group in groups)
              {
                  Console.WriteLine("Key: "+group.Key);
                  foreach (var course in group)
                  {
                      Console.WriteLine("\t"+course.Name);
                  }
              }*/

            /*  var courseWithAuthor = context.Course.Join(context.Author, c => c.AuthorId, a => a.Id, (course, author) => new
               {
                   CourseName = course.Name,
                   CourseDescription = course.Description,
                   CourseCover = course.Cover,
                   AuthorName = author.Name,
               });
              foreach (var course in courseWithAuthor)
              {
                  Console.WriteLine("Course Name: {0} \nCourse Cover: {1}\nCourse Description: {2}\nAuthor Name: {3} ",course.CourseName,course.CourseCover,course.CourseDescription,course.AuthorName);
              }*/

            /*   var authorCourses = context.Author.GroupJoin(context.Course, a => a.Id, c => c.AuthorId,
                     (author, course) => new { Author = author.Name, Courses = course.Count() });

               foreach (var author in authorCourses)
               {
                   Console.WriteLine("Author Name {0} - Courses {1}", author.Author,author.Courses);

               }*/

            /*  var allAuthorCourse =   context.Author.SelectMany(a => context.Course,
                     (author, course) => new {AuthorName = author.Name, CourseName = course.Name});

                 foreach (var course in allAuthorCourse)
                 {
                     Console.WriteLine("{0},{1}",course.CourseName,course.AuthorName);
                 }*/
            /*  var course = context.Covers.OrderBy(c=>c.CoverId).ThenBy(c=>c.CoverName).FirstOrDefault();
              if (course==null)
              {
                  Console.WriteLine("get an exception");
              }*/
            /*    var courses = context.Course;
                var filteredCourses = context.Course.Where(c => c.Level == 1);
                var sorted = context.Course.OrderBy(c => c.Name);
                foreach (var course in filteredCourses)
                {
                    Console.WriteLine(course.Name);
                }*/
            var course = context.Course.Find(3);
            course.Name = "Naw Name";
            course.AuthorId = 2;

            context.SaveChanges();


            Console.ReadKey();
        }
    }
}
