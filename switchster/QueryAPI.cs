using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class QueryAPI {
    public string apiUrl;
    protected async Task<string> GetPublicDataJson(string queryString)
    {
      //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
      string json = "";
      HttpClient client = new HttpClient();
      var response = await client.GetAsync(queryString);
      if (response != null)
      {
        json = response.Content.ReadAsStringAsync().Result;
      }
      System.Console.WriteLine("Queried {0} -> {1} bytes returned.", queryString, json.Length);
      return json;
    }
  }
}