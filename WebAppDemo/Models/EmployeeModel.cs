using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebAppDemo.Entities;

namespace WebAppDemo.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string FullName { get; set; }

        [Required]
        public int DesignationId { get; set; }

        public List<Designation> Designations { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateofJoining { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string MobileNo { get; set; }

        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }


        [StringLength(200)]
        public string Location { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }
    }
}
