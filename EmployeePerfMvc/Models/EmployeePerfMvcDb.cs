using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeePerfMvc.Models
{
    public class EmployeePerfMvcDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GoalAppraisal> GoalAppraisals { get; set; }
    }
}