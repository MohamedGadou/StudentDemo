using Microsoft.EntityFrameworkCore;
using StudentDemo.Domain.Entities;
using StudentDemo.Domain.IRepos;
using StudentDemo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Infrastructure.Repos
{
    public class CourseRepo : ICourseRepo
    {
        private readonly StudentDemoDbContext _dbContext;

        public CourseRepo(StudentDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(Expression<Func<Course, bool>> filter)
        {
            var entities = await _dbContext.Courses.Where(filter).ToListAsync();

            _dbContext.RemoveRange(entities);
        }

        public async Task<IList<Course>> GetListAsync(Expression<Func<Course, bool>> filter)
        {
            return await _dbContext.Courses.Where(filter).ToListAsync();
        }

        public async Task<Course> InsertAsync(Course course)
        {
            var obj = await _dbContext.AddAsync(course);
            return obj.Entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync()) > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
