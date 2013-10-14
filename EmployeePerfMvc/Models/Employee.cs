using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePerfMvc.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int ManagerId { get; set; }
        public virtual ICollection<GoalAppraisal> GoalAppraisals { get; set; }
    }
 }