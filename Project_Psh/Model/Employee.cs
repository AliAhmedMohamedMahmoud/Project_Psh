using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project_Psh.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        [ForeignKey("department")]
        public int DeptId { get; set; }
        [JsonIgnore]
        public Department department { get; set; }

    }
}
