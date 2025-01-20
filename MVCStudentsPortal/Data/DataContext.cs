using MVCStudentsPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Data
{
    //non persistent data employees
    public class DataContext
    {
        private List<Employees> _employee = new List<Employees>();

        public List<Employees> GetEmployees()
        {
            return _employee;
        }

        public Employees Create(Employees employees) 
        {
            employees.Id = _employee.Count() + 1;
            _employee.Add(employees);
            return employees;
        }

        public Employees Update(Employees employees) 
        {
            var updateData = _employee.Where(x => x.Id == employees.Id).FirstOrDefault();
            if (updateData != null) 
            { 
                updateData.Name = employees.Name;
                updateData.Phone = employees.Phone;
                updateData.Address = employees.Address;
                updateData.Salary= employees.Salary;

            }
            return employees;
        }

        public Employees Delete(Employees employees) 
        { 
            _employee.RemoveAt(employees.Id);
            return employees;
        }


    }
}
