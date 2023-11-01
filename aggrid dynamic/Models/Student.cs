using System.ComponentModel.DataAnnotations;

namespace aggrid_dynamic.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public long PhoneNo { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

    }
}
