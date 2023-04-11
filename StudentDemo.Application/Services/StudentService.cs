using StudentDemo.Domain.Entities;
using StudentDemo.Domain.IRepos;
using StudentDemo.Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        private readonly ICourseRepo _courseRepo;
        public StudentService(IStudentRepo studentRepo, ICourseRepo courseRepo)
        {
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
        }
        public async Task<Student> CreateAsync(string name, string corelationId)
        {
            var courses = await _courseRepo.GetListAsync(course => course.CorelationId == corelationId);

            var student = Student.Create(Guid.NewGuid(), name, courses);
            student.CorelationId = corelationId;

            await _studentRepo.InsertAsync(student);

            if (await _studentRepo.SaveChangesAsync())
            {
                return student;
            }
            else
            {
                await _courseRepo.DeleteAsync(course => course.CorelationId == corelationId);
                await _courseRepo.SaveChangesAsync();

                throw new InvalidOperationException();
            }

        }
    }
}
