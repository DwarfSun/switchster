using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class YiimpQueryAPI {
    public string apiUrl;// = @"http://api.zergpool.com:8080/api/";
    public YiimpQueryAPI(string _apiUrl = @"http://api.zergpool.com:8080/api/") {
      apiUrl = _apiUrl;
    }
    private async Task<string> FetchData(string command)
    {
      string queryString = apiUrl + command;
      string json = "";
      HttpClient client = new HttpClient();
      var response = await client.GetAsync(queryString);
      //dynamic data = null;
      if (response != null)
      {
        //JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        json = response.Content.ReadAsStringAsync().Result;
      }
      return json;
    }

    public async void WalletStatus(string wallet) {
      string command = string.Format("wallet?address={0}", wallet);
      dynamic results = await FetchData(command);
    }
    public async void WalletDetail(string wallet) {
      string command = string.Format("walletEx?address={0}", wallet);
      dynamic results = await FetchData(command);
    }
    public async void PoolStatus() {
      string command = string.Format("status");
      dynamic results = await FetchData(command);
    }
    public async Task<Dictionary<string, YiimpCurrency>> Currencies() {
      Dictionary<string, YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
      string command = string.Format("currencies");
      string results = await FetchData(command);
      currencies = JsonConvert.DeserializeObject<Dictionary<string, YiimpCurrency>>(results);
/*
        foreach (var result in results) {
        YiimpCurrency currency = new YiimpCurrency();
        currency.algo = result["algo"];
        currency.port = result["port"];
        currency.name = result["name"];
        currency.height = result["height"];
        currency.workers = result["workers"];
        currency.shares = result["shares"];
        currency.hashrate = result["hashrate"];
        currency._24h_blocks = result["24h_blocks"];
        currency._24h_btc = result["24h_btc"];
        currency.lastblock = result["lastblock"];
        currency.timesincelast = result["timesincelast"];
        currencies.Add(currency);
      }
*/
      return currencies;
    }
    public async void Blocks() {
      string command = string.Format("blocks");
      dynamic results = await FetchData(command);
    }
    public async void Miners() {
      string command = string.Format("miners");
      dynamic results = await FetchData(command);
    }
  }
}