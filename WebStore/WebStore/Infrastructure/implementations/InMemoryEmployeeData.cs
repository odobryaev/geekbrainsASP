using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.Infrastructure.interfaces;

namespace WebStore.Infrastructure.implementations
{
    public class InMemoryEmployeeData : IEmployeesData
    {
        private readonly List<Employee> _Employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Иван", MiddleName= "Петрович", LastName = "Смирнов", Age=30, HiredDate=new DateTime(2010, 5, 20)},
            new Employee { Id = 2, FirstName = "Петр", MiddleName= "Иванович", LastName = "Романов", Age=25, HiredDate=new DateTime(2012, 1, 16)},
            new Employee { Id = 3, FirstName = "Александр", MiddleName= "Александрович", LastName = "Сидоров", Age=22, HiredDate=new DateTime(2015, 10, 1)},
        };

        public IEnumerable<Employee> GetAll()
        {
            return _Employees;
        }

        public Employee GetById(int id)
        {
            return _Employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddNew(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            if (_Employees.Contains(employee) || _Employees.Any(e => e.Id == employee.Id)) return;

            employee.Id = _Employees.Count == 0 ? 1 : _Employees.Max(e => e.Id) + 1;
            _Employees.Add(employee);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null) return;
            _Employees.Remove(employee);
        }

        public void SaveChanges()
        {         
        }
    }
}
