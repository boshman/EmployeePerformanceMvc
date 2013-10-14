using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePerfMvc.Models
{
    public class GoalAppraisal
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Year { get; set; }
        public string Goal{ get; set; }
        public string EmployeeAppraisal { get; set; }
        public string ManagerAppraisal { get; set; }
    }
}