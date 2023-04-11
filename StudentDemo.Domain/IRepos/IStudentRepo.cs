using StudentDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Domain.IRepos
{
    public interface IStudentRepo
    {
        public Task<Student> InsertAsync(Student course);
        public Task<bool> SaveChangesAsync();
    }
}
