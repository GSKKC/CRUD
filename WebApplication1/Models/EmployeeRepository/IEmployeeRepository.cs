using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllData();
        bool Save(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
    }
}
