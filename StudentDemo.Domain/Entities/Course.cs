using StudentDemo.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Domain.Entities
{
    public class Course: IUserCorelationId
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Student Student { get; private set; }
        public string CorelationId { get; set; }

        private Course()
        {

        }
        private Course(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Course Create(Guid id, string name)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("id");

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name");

            return new Course(id, name);
        }

        public void AddStudent(Student student)
        {
            Student = student;
        }

    }
}
