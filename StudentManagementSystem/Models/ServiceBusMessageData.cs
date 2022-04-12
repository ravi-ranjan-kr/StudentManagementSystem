using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class ServiceBusMessageData
    {
        public int? StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public int? Marks { get; set; }
        public int? Sem { get; set; }
    }
}
