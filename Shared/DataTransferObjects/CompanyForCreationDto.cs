using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record CompanyForCreationDto (string name, string Address, string country,
        IEnumerable<EmployeeForCreationDto> Employees);
}
