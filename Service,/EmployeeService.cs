using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {

            var employees = _repository.Employee.GetAllEmployees(trackChanges);

            var employeesDto = employees.Select(e => new EmployeeDto(e.Id, e.Name, e.Age, e.Position, e.CompanyId));
            return employeesDto;

        }

        public EmployeeDto GetEmployee(Guid employeeId, bool trackChanges)
        {
            var employee = _repository.Employee.GetEmployee(employeeId, trackChanges);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;

        }
    }
}
