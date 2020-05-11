using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using scholarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scholarSystem.DAL
{
    public static class DbInitializer
    {
        //SEEDING
        public static void Seed(IApplicationBuilder builder) 
        { 
             using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ScholarSystemContext>();

                //if(!context.Students.Any())
                //{
                //    context.Students.AddRange(Students.Values);
                //}

                //if (!context.Groups.Any())
                //{
                //    var groupsList = new List<Group>
                //    {
                //        new Group(){GroupName = "1°A", GroupStudents = 3},
                //        new Group(){GroupName = "2°A", GroupStudents = 0},
                //        new Group(){GroupName = "3°A", GroupStudents = 0}
                //    };
                //}
                //context.SaveChanges();

                if (!context.Groups.Any())
                {
                    context.Groups.AddRange(Groups.Values);
                }

                if (!context.Students.Any())
                {
                    var studentList = new List<Student>
                    {
                        new Student(){StudentName = "Juan Deagle", Group = Groups["1°A"], StudentAverage = 0},
                        new Student(){StudentName = "Nicole Delgado", Group = Groups["1°A"], StudentAverage = 0},
                        new Student(){StudentName = "Conejo Blaz", Group = Groups["1°A"], StudentAverage = 0}
                    };

                    //this fill the db's table
                    context.Students.AddRange(studentList);
                }
                context.SaveChanges();

            }
        }

        //private static Dictionary<string, Student> _students;

        //public static Dictionary<string, Student> Students
        //{
        //    get
        //    {
        //        if (_students != null)
        //        {
        //            return _students;
        //        }

        //        var studentList = new[]
        //        {
        //            new Student(){StudentName = "Juan Deagle", GroupId = 1},
        //            new Student(){StudentName = "Nicole Delgado", GroupId = 1},
        //            new Student(){StudentName = "Conejo Blaz", GroupId = 1}

        //        };

        //        _students = new Dictionary<string, Student>();

        //        foreach (var student in studentList)
        //        {
        //            _students.Add(student.StudentName, student);
        //        }

        //        return _students;
        //    }
        //}

        private static Dictionary<string, Group> _groups;

        public static Dictionary<string, Group> Groups
        {
            get
            {
                if (_groups != null)
                {
                    return _groups;
                }

                var groupList = new[]
                {
                    new Group(){GroupName = "1°A"},
                    new Group(){GroupName = "2°A"},
                    new Group(){GroupName = "3°A"}

                };

                _groups = new Dictionary<string, Group>();

                foreach (var group in groupList)
                {
                    _groups.Add(group.GroupName, group);
                }

                return _groups;
            }
        }
    }

}
