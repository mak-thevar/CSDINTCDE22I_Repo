using Microsoft.VisualBasic;

namespace WebAppDemo.Services
{

    public interface IEmployeeService
    {
        public string DefaultMessage { get; set; }
        string Display();
    }

    public class EmployeeService : IEmployeeService
    {
     
        public string DefaultMessage { get; set; } = "Hello World";
        public string Display()
        {
           return DefaultMessage;
        }
    }
}
