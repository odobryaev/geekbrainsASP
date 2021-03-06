﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 0, FirstName = "Иван", MiddleName= "Петрович", LastName = "Смирнов", Age=30, HiredDate=new DateTime(2010, 5, 20)},
            new Employee { Id = 1, FirstName = "Петр", MiddleName= "Иванович", LastName = "Романов", Age=25, HiredDate=new DateTime(2012, 1, 16)},
            new Employee { Id = 2, FirstName = "Александр", MiddleName= "Александрович", LastName = "Сидоров", Age=22, HiredDate=new DateTime(2015, 10, 1)},
        };

        public IActionResult Index()
        {
            return View(_employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Add()
        {
            int nextId = _employees.Max(i => i.Id) + 1;
            Employee employee = new Employee { Id = nextId };
            _employees.Add(employee);
            return View("Index",_employees);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee employeeEdit)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            int i = _employees.IndexOf(employee);
            _employees[i].LastName = employeeEdit.LastName;
            _employees[i].FirstName = employeeEdit.FirstName;
            _employees[i].MiddleName = employeeEdit.MiddleName;
            _employees[i].Age = employeeEdit.Age;
            _employees[i].HiredDate = employeeEdit.HiredDate;
            return View("Index",_employees);
        }

        public IActionResult Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _employees.Remove(employee);
            return View("Index", _employees);
        }


    }
}