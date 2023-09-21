using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
          FindAll(trackChanges)
          .OrderBy(e => e.Name)
          .ToList();

        

        public Employee GetEmployee(Guid employeeId, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(employeeId), trackChanges)
            .SingleOrDefault();

    }
}
