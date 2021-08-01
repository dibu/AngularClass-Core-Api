using System;
using System.Collections.Generic;

#nullable disable

namespace AngularClass_Core_Api.Models
{
    public partial class EmpDetail
    {
        public EmpDetail()
        {
            SalaryDetails = new HashSet<SalaryDetail>();
        }

        public int Id { get; set; }
        public string EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Designation { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Designation DesignationNavigation { get; set; }
        public virtual ICollection<SalaryDetail> SalaryDetails { get; set; }
    }
}
