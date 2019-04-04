using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> GetAll();

        Employee getById(int id);

        void Delete(int id);

    }
}
