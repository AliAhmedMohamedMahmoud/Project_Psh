using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project_Psh.Model
{
    public class Department
    {

        public int Id { get; set; }
        public string DeptName { get; set; }
        public string MangerName { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();

    }
}
