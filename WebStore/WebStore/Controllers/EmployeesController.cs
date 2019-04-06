﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }

        public IActionResult Index()
        {
            return View(_EmployeesData.GetAll());
        }

        public IActionResult Details(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            Employee employee;
            if (id != null)
            {
                employee = _EmployeesData.GetById((int)id);
                if (employee is null)
                    return NotFound();
            }
            else
            {
                employee = new Employee();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            if (employee.Id > 0)
            {
                var db_employee = _EmployeesData.GetById(employee.Id);
                if (db_employee is null)
                    return NotFound();
                db_employee.LastName = employee.LastName;
                db_employee.FirstName = employee.FirstName;
                db_employee.MiddleName = employee.MiddleName;
                db_employee.Age = employee.Age;
                db_employee.HiredDate = employee.HiredDate;
            }
            else
            {
                _EmployeesData.AddNew(employee);
            }
            _EmployeesData.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            _EmployeesData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}