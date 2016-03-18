using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Core
{
    public interface IDepartmentDataSource
    {
        IQueryable<Employee> Employee { get; }
        IQueryable<Department> Departments { get; }
        void Save();
    }
    
}
