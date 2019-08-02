using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using WebApplication1.Models.EmployeeRepository;

namespace WebApplication1.Models.Business
{
    public class BEmployee
    {
        private readonly EmployeeRepository.EmployeeRepository employeec = null;
        public BEmployee()
        {
            employeec = new EmployeeRepository.EmployeeRepository();
        }
        public List<Employee> GetAllData()
        {
            return employeec.GetAllData();
        }
        public bool Create(Employee employee)
        {
            return employeec.Save(employee);
        }
        public bool Delete(Employee employee)
        {
            return employeec.Delete(employee); 
        }
        public bool Update(Employee employee)
        {
            return employeec.Update(employee);
        }
    }
}