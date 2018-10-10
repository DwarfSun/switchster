using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class CoinGeckoQueryAPI : QueryAPI {
    public CoinGeckoQueryAPI(){
      apiUrl = @"https://api.coingecko.com/api/v3/";
    }
    public async Task<List<CoinGeckoCoin>> CoinList() {
      List<CoinGeckoCoin> coinlist = new List<CoinGeckoCoin>();
      string command = string.Format("{0}coins/markets?vs_currency=btc", apiUrl);
      string response = await GetPublicDataJson(command);
      //System.Console.WriteLine(response);
      coinlist = JsonConvert.DeserializeObject<List<CoinGeckoCoin>>(response);
      return coinlist;
    }
  }
}