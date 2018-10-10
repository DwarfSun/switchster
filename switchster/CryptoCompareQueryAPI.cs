using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class CryptoCompareCoinListResponse {
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
  public class CryptoCompareCoinInfoResponse {
    [JsonProperty("Message")]
    public string message;
    [JsonProperty("Type")]
    public int type;
    [JsonProperty("Data")]
    public List<CryptoCompareGeneralInfo> data;
  }
  public class CryptoCompareQueryAPI : QueryAPI {
    const string minApiUrl = @"https://min-api.cryptocompare.com/data/";
    const string oldApiUrl = @"https://www.cryptocompare.com/api/data/";
    public async Task<Dictionary<string, CryptoCompareCoin>> CoinList() {
      CryptoCompareCoinListResponse cryptoCompareCoinListResponse = new CryptoCompareCoinListResponse();
      Dictionary<string, CryptoCompareCoin> coinlist = new Dictionary<string, CryptoCompareCoin>();
      string command = string.Format("{0}all/coinlist", minApiUrl);
      string response = await GetPublicDataJson(command);
      cryptoCompareCoinListResponse = JsonConvert.DeserializeObject<CryptoCompareCoinListResponse>(response);
      return cryptoCompareCoinListResponse.data;
    }

    //https://min-api.cryptocompare.com/data/coin/generalinfo?fsyms=BTC,MLN,DASH&tsym=USD
    public async Task<Dictionary<string, CryptoCompareCoinInfo>> CoinInfo(string coin) {
      CryptoCompareCoinInfoResponse cryptoCompareCoinInfoResponse = new CryptoCompareCoinInfoResponse();
      Dictionary<string, CryptoCompareCoinInfo> coinlist = new Dictionary<string, CryptoCompareCoinInfo>();
      string command = string.Format("{0}coin/generalinfo?fsyms={1}&tsym=BTC", minApiUrl, coin);
      string response = await GetPublicDataJson(command);
      cryptoCompareCoinInfoResponse = JsonConvert.DeserializeObject<CryptoCompareCoinInfoResponse>(response);
      foreach(CryptoCompareGeneralInfo g in cryptoCompareCoinInfoResponse.data){
        coinlist.Add(g.coinInfo.symbol, g.coinInfo);
      }
      return coinlist;
    }
    
  }
}