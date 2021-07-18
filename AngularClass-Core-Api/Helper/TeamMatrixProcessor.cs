using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
namespace AngularClass_Core_Api.Helper {
    public class TeamMatrixProcessor {
        private readonly JArray teamMatrixData;

        public TeamMatrixProcessor() {
            using (StreamReader reader = new StreamReader("SampleResponse/TeamMatrix.json")) {
                string dataContent = reader.ReadToEnd();
                if (dataContent.StartsWith("[") && dataContent.EndsWith("]")) {
                    teamMatrixData = JArray.Parse(dataContent);
                }
            }
        }

        public IList<TeamMatrixData> processMatrixData(string[] keyNames) {
            List<TeamMatrixData> response = new List<TeamMatrixData>();
            try {

                foreach (string keyName in keyNames) {
                    IDictionary<string, JToken> currentObject = (JObject)this.teamMatrixData.Where(d => d["name"].ToString() == keyName).FirstOrDefault();
                    
                    TeamMatrixData teamMatrixData = new TeamMatrixData();

                    teamMatrixData.id = currentObject["id"].ToString();
                    teamMatrixData.name = keyName;
                    teamMatrixData.timestamp= currentObject["timestamp"].ToString();

                    if (currentObject.ContainsKey("data")) {
                        string rawdata = currentObject["data"].ToString();
                        var token = JToken.Parse(rawdata);
                        if (token is JObject) {
                            teamMatrixData.data = (JObject)token;
                        } else if(token is JArray) {
                            teamMatrixData.data = (JArray)token;
                        }
                    }

                    response.Add(teamMatrixData);

                }

                  

            } catch {
               
            }
            return response;
        }
    }
}
