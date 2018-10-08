using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class YiimpServer {
    private YiimpQueryAPI api;
    public Dictionary<string, YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
    public YiimpServer(string apiUrl = @"http://api.zergpool.com:8080/api/") {
      api = new YiimpQueryAPI(apiUrl);
      currencies = api.Currencies().Result;
    }
  }
}