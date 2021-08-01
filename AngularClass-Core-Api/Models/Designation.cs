using System;
using System.Collections.Generic;

#nullable disable

namespace AngularClass_Core_Api.Models
{
    public partial class Designation
    {
        public Designation()
        {
            EmpDetails = new HashSet<EmpDetail>();
        }

        public int Id { get; set; }
        public string Designation1 { get; set; }

        public virtual ICollection<EmpDetail> EmpDetails { get; set; }
    }
}
