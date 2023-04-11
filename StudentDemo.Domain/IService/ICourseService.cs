﻿using StudentDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Domain.IService
{
    public interface ICourseService
    {
        public Task<Course> CreateAsync(string name, string corelationId);

    }
}
