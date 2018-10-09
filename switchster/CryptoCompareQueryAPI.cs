using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class ResponseCoinList {

    [JsonProperty("Response")]
    public string response;
    [JsonProperty("Message")]
    public string message;
    [JsonProperty("Data")]
    public Dictionary<string, CryptoCompareCoin> data;
    [JsonProperty("BaseImageUrl")]
    public string baseImageUrl;
    [JsonProperty("BaseLinkUrl")]
    public string baseLinkUrl;
  }
  public class CryptoCompareQueryAPI {
    const string minApiUrl = @"https://min-api.cryptocompare.com/data";
    const string oldApiUrl = @"https://www.cryptocompare.com/api/data";

    private async Task<string> FetchData(string queryString)
    {
      string json = "";
      HttpClient client = new HttpClient();
      var response = await client.GetAsync(queryString);
      if (response != null)
      {
        json = response.Content.ReadAsStringAsync().Result;
      }
      return json;
    }
    
    public async Task<Dictionary<string, CryptoCompareCoin>> CoinList() {
      ResponseCoinList responseCoinList = new ResponseCoinList();
      Dictionary<string, CryptoCompareCoin> coinlist = new Dictionary<string, CryptoCompareCoin>();
      string command = minApiUrl + "/all/coinlist";
      string response = await FetchData(command);
      responseCoinList = JsonConvert.DeserializeObject<ResponseCoinList>(response);
      return responseCoinList.data;
    }
  }
}