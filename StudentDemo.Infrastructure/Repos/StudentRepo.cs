using StudentDemo.Domain.Entities;
using StudentDemo.Domain.IRepos;
using StudentDemo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Infrastructure.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentDemoDbContext _dbContext;

        public StudentRepo(StudentDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> InsertAsync(Student student)
        {
            var obj = await _dbContext.AddAsync(student);
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
