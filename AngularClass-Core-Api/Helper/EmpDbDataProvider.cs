using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularClass_Core_Api.ViewModels;
using AngularClass_Core_Api.Models;
using Microsoft.EntityFrameworkCore;
namespace AngularClass_Core_Api.Helper {
    public class EmpDbDataProvider {
        private readonly EmpDbContext dbContext;
        public EmpDbDataProvider() {
            dbContext = new EmpDbContext();
        }

        public Employee GetEmployee(int empId) {
            var data = dbContext.EmpDetails.Where(e => e.Id == empId).Join(dbContext.Designations,
              
                // On
                emp => emp.Designation,
                desg => desg.Id,

                (emp, desg) => new {
                    EmpId = empId,
                    Designation = desg.Designation1,
                    Name = emp.FirstName + " " + emp.LastName
                }).Join(dbContext.SalaryDetails,

                // On
                emp => emp.EmpId, 
                salary => salary.EmpId, 
                
                (emp, salary) => new Employee() { 
                    EmpId = emp.EmpId,
                    Designation = emp.Designation,
                    Name = emp.Name,
                    Salary = salary.CurrentSalary
                }).FirstOrDefault();
            return data;
        }

        public List<Employee> GetAllEmployees() {
            var data = dbContext.EmpDetails.Join(dbContext.Designations,

                emp => emp.Designation,
                desg => desg.Id,

                (emp, desg) => new {
                    EmpId = emp.Id,
                    Designation = desg.Designation1,
                    Name = emp.FirstName + " " + emp.LastName
                }).Join(dbContext.SalaryDetails,

                emp => emp.EmpId,
                salary => salary.EmpId,

                (emp, salary) => new Employee() {
                    EmpId = emp.EmpId,
                    Designation = emp.Designation,
                    Name = emp.Name,
                    Salary = salary.CurrentSalary
                }).ToList();
            return data;
        }

        public object TestLeftJoin() {
            var data = dbContext.EmpDetails.Where(s => s.FirstName == "Mriganka").Include(d => d.DesignationNavigation).FirstOrDefault();
            return data;
        }
    }
}
