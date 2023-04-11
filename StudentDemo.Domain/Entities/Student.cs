using StudentDemo.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Domain.Entities
{
    public class Student: IUserCorelationId
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Course> Courses { get; private set; }
        public string CorelationId { get ; set; }

        private Student()
        {

        }

        private Student(Guid id, string name, ICollection<Course> courses)
        {
            Id = id;
            Name = name;
            Courses = courses;
        }

        public static Student Create(Guid id, string name, ICollection<Course> courses)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("id");

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name");

            return new Student(id, name, courses);
        }

    }
}
