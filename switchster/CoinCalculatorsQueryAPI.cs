using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class CoinCalculatorsQueryAPI : QueryAPI {
    public CoinCalculatorsQueryAPI(){
      apiUrl = @"https://www.coincalculators.io/";
    }
    public static CoinCalculatorsCoin lastCoin = new CoinCalculatorsCoin();
    public async Task<List<CoinCalculatorsCoin>> CoinList() {
      List<CoinCalculatorsCoin> coinlist = new List<CoinCalculatorsCoin>();
      string command = string.Format("{0}api/allcoins.aspx?hashrate=1000", apiUrl);
      string response = await GetPublicDataJson(command);
      coinlist = JsonConvert.DeserializeObject<List<CoinCalculatorsCoin>>(response);
      return coinlist;
    }
    public async Task<CoinCalculatorsCoin> SpecificCoin(string coinName) {
      //CoinCalculatorsCoin coin = new CoinCalculatorsCoin();
      string command = string.Format("{0}api.aspx?name={1}&hashrate=1000", apiUrl, coinName.ToLower());
      string response = await GetPublicDataJson(command);
      lastCoin = JsonConvert.DeserializeObject<CoinCalculatorsCoin>(response);
      return lastCoin;
    }
  }
}