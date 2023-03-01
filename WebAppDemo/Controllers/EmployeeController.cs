using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDemo.Data;
using WebAppDemo.Entities;
using WebAppDemo.Models;
using WebAppDemo.Services;

namespace WebAppDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DefaultContext context;
        private readonly IEmployeeService employeeService;

        public EmployeeController(DefaultContext context)
        {
            this.context = context;
          
        }


        public async Task<IActionResult> Index()
        {
            var services = this.HttpContext.RequestServices;
            var empService =  services.GetService<IEmployeeService>();

            empService.DefaultMessage = "The message has been changed";

            var result = await context.Departments.ToListAsync();
            return View(result);
        }

        public async Task<IActionResult> ListEmp()
        {
            var employees = await context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var listOfDep = await context.Departments.ToListAsync();
            var listOfDesig = await context.Designations.ToListAsync();

            var empModel = new EmployeeModel { Departments = listOfDep, Designations = listOfDesig };

            return View(empModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel employeeModel)
        {
            var entityClass = new Employee
            {
                DateofJoining = employeeModel.DateofJoining,
                DepartmentId = employeeModel.DepartmentId,
                DesignationId = employeeModel.DepartmentId,
                FullName = employeeModel.FullName,
                Location = employeeModel.Location,
                MobileNo = employeeModel.MobileNo,
                Salary = employeeModel.Salary,
            };

            var result = await context.Employees.AddAsync(entityClass);
            await context.SaveChangesAsync();

            return RedirectToAction("ListEmp");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var emp = await context.Employees.FindAsync(id);
            if (emp is null)
                return NotFound();


            var listOfDep = await context.Departments.ToListAsync();
            var listOfDesig = await context.Designations.ToListAsync();

            var empModel = new EmployeeModel
            {
                DateofJoining = emp.DateofJoining,
                DepartmentId = emp.DepartmentId,
                DesignationId = emp.DesignationId,
                FullName = emp.FullName,
                Id = emp.Id,
                Location = emp.Location,
                MobileNo = emp.Location,
                Salary = emp.Salary,
                Departments = listOfDep,
                Designations = listOfDesig
            };

            return View(empModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel employeeModel)
        {

            var dbEmployee = await context.Employees.FindAsync(employeeModel.Id);

            if (dbEmployee is null)
                return NotFound();


            dbEmployee.FullName = employeeModel.FullName;
            dbEmployee.Salary = employeeModel.Salary;
            dbEmployee.Location = employeeModel.Location;
            dbEmployee.DesignationId = employeeModel.DesignationId;
            dbEmployee.DepartmentId = employeeModel.DepartmentId;
            employeeModel.MobileNo = employeeModel.MobileNo;


            context.Employees.Remove(dbEmployee);
            await context.SaveChangesAsync();

            return RedirectToAction("ListEmp");
        }
    }
}
