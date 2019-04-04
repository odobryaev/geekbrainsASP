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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee getById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
