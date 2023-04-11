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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _courseRepo;
        public CourseService(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public async Task<Course> CreateAsync(string name, string corelationId)
        {
            var course = Course.Create(Guid.NewGuid(), name);
            course.CorelationId = corelationId;

            await _courseRepo.InsertAsync(course);

            await _courseRepo.SaveChangesAsync();

            return course;
        }
    }
}
