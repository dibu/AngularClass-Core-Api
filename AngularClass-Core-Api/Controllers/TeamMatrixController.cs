using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using AngularClass_Core_Api.Helper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace AngularClass_Core_Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMatrixController : ControllerBase {
        private readonly TeamMatrixProcessor matrixProcessor;
        public TeamMatrixController() {
            matrixProcessor = new TeamMatrixProcessor();
        }

        [HttpPost]
        public JToken GetDataByKeyName(string[] keyName) {
                 
            return JToken.Parse(JsonConvert.SerializeObject(matrixProcessor.processMatrixData(keyName)));
        }
    }
}
