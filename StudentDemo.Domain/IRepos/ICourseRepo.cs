using StudentDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Domain.IRepos
{
    public interface ICourseRepo
    {
        public Task<Course> InsertAsync(Course course);
        public Task<IList<Course>> GetListAsync(Expression<Func<Course, bool>> filter);
        public Task DeleteAsync(Expression<Func<Course, bool>> filter);
        public Task<bool> SaveChangesAsync();
    }
}
