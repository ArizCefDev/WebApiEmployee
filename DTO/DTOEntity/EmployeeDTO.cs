using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
    }
}
