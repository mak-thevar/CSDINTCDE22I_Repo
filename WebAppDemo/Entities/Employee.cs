using System.ComponentModel.DataAnnotations;

namespace WebAppDemo.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string FullName { get; set; }
        
        public int DesignationId { get; set; }

        public virtual Designation Designation { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime DateofJoining { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string MobileNo { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }
    }
}
