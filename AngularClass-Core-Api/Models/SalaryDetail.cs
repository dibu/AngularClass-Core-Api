using System;
using System.Collections.Generic;

#nullable disable

namespace AngularClass_Core_Api.Models
{
    public partial class SalaryDetail
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public decimal LastSalary { get; set; }
        public DateTime LastAppraisalDate { get; set; }
        public double Hike { get; set; }
        public decimal CurrentSalary { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual EmpDetail Emp { get; set; }
    }
}
