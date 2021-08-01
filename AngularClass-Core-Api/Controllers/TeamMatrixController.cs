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
using AngularClass_Core_Api.Models;

namespace AngularClass_Core_Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMatrixController : ControllerBase {
        private readonly TeamMatrixProcessor matrixProcessor;
        EmpDbDataProvider empDbDataProvider;
        public TeamMatrixController() {
            matrixProcessor = new TeamMatrixProcessor();
            empDbDataProvider = new EmpDbDataProvider();
        }

        [HttpPost]
        public JToken GetDataByKeyName(string[] keyName) {
                 
            return JToken.Parse(JsonConvert.SerializeObject(matrixProcessor.processMatrixData(keyName)));
        }

        [HttpGet("GetChartData")]
        public List<KeyValuePair<int, string>> GetChartData() {
            return matrixProcessor.GetChartTypes();
        }

        [HttpGet("GetEmployee")]
        public ViewModels.Employee GetEmployee(int empId) {
            return empDbDataProvider.GetEmployee(empId);
        }

        [HttpGet("GetAllEmployees")]
        public List<ViewModels.Employee> GetAllEmployees() {
            return empDbDataProvider.GetAllEmployees();
        }

        [HttpGet("TestLeftJoin")]
        public object TestLeftJoin() {
            return empDbDataProvider.TestLeftJoin();
        }
    }
}
