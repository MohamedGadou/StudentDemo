using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Domain.Shared
{
    public interface IUserCorelationId
    {
        public string CorelationId { get; set; }
    }
}
