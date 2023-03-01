using System.ComponentModel.DataAnnotations;

namespace WebAppDemo.Entities
{
    public class Designation
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
