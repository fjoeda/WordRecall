using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordRecall.Methods
{
    public class WitHelper
    {
        RestClient client;
        public WitHelper()
        {
            client = new RestClient();
        }
        public async Task<string> GetIntent(string message)
        {
            var request = new RestRequest("https://api.wit.ai/message", Method.GET);
            request.AddHeader("Authorization", "Bearer LDZE4NWCGIS7XEAXEI572FXZVETO5JEF");
            request.AddParameter("q", message);
            var response = await client.ExecuteAsync(request);
            var responseObj = JsonConvert.DeserializeObject<WitResponse>(response.Content);
            double maxConf = -99;
            string intentResult = "";
            try
            {
                if (responseObj.Intent != null)
                {
                    foreach (var intent in responseObj.Intent)
                    {
                        if (intent.Confidence > maxConf)
                        {
                            intentResult = intent.Name;
                            maxConf = intent.Confidence;
                        }
                    }
                }
                
                return intentResult;
            }catch(Exception e)
            {
                return null;
            }
            
        }
    }

    class WitResponse
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "intents")]
        public List<WitIntent> Intent { get; set; }
    }
    class WitIntent
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }

    }
}
