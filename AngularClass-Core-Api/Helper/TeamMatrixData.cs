using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace AngularClass_Core_Api.Helper {

    public class TeamMatrixData {
        public string id { get; set; }
        public string name { get; set; }
        public JToken data { get; set; }
        public string timestamp { get; set; }

    }
}
