using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DepartmentService:IDepartmentService  
    {
        private readonly List<Department> _departments = new List<Department>();
        public DepartmentService()
        {
            _departments.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "Beijing"
            });
            _departments.Add(new Department
            {
                Id = 2,
                Name = "R&D",
                EmployeeCount = 52,
                Location = "Shanghai"
            });
            _departments.Add(new Department
            {
                Id = 3,
                Name = "Sale",
                EmployeeCount = 200,
                Location = "China"
            });
        }


        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(()=>_departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() => _departments.FirstOrDefault(x=>x.Id ==id));
        }

        public Task<CompanySummery> GetCompanySummery()
        {
            return Task.Run(() =>
            {
                return new CompanySummery
                {
                    EmployCount = _departments.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCout = (int)_departments.Average(x => x.EmployeeCount)
                };
            });
        }

        public Task Add(Department department)
        {
            department.Id = _departments.Max(x => x.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }

    }
}
