using System;
using System.Collections.Generic;

#nullable disable

namespace AngularClass_Core_Api.Models
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public string ProcName { get; set; }
        public string ErrorDetails { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
