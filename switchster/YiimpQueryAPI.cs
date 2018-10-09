using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class YiimpQueryAPI {
    public string apiUrl;
    public YiimpQueryAPI(string _apiUrl = @"http://api.zergpool.com:8080/api/") {
      apiUrl = _apiUrl;
    }
    private async Task<string> FetchData(string command)
    {
      string queryString = apiUrl + command;
      string json = "";
      HttpClient client = new HttpClient();
      var response = await client.GetAsync(queryString);
      if (response != null)
      {
        json = response.Content.ReadAsStringAsync().Result;
      }
      else
      {
        //System.Console.Error.Write("Null response! ");
      }
      System.Console.WriteLine("Queried {0} -> {1} bytes returned.", queryString, json.Length);
      return json;
    }

    public async Task<YiimpWallet> WalletStatus(string wallet) {
      YiimpWallet walletSimple = new YiimpWallet();
      string command = string.Format("wallet?address={0}", wallet);
      string results = await FetchData(command);
      walletSimple = JsonConvert.DeserializeObject<YiimpWallet>(results);
      return walletSimple;
    }
    public async Task<YiimpWalletDetail> WalletDetail(string wallet) {
      YiimpWalletDetail walletDetail = new YiimpWalletDetail();
      string command = string.Format("walletEx?address={0}", wallet);
      string results = await FetchData(command);
      walletDetail = JsonConvert.DeserializeObject<YiimpWalletDetail>(results);
      return walletDetail;
    }
    public async Task<Dictionary<string, YiimpStatus>> PoolStatus() {
      Dictionary<string, YiimpStatus> statuses = new Dictionary<string, YiimpStatus>();
      string command = string.Format("status");
      string results = await FetchData(command);
      statuses = JsonConvert.DeserializeObject<Dictionary<string, YiimpStatus>>(results);
      return statuses;
    }
    public async Task<Dictionary<string, YiimpCurrency>> Currencies() {
      Dictionary<string, YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
      string command = string.Format("currencies");
      string results = await FetchData(command);
      currencies = JsonConvert.DeserializeObject<Dictionary<string, YiimpCurrency>>(results);
      return currencies;
    }
    public async Task<List<YiimpBlock>> Blocks() {
      List<YiimpBlock> blocks = new List<YiimpBlock>();
      string command = string.Format("blocks");
      string results = await FetchData(command);
      blocks = JsonConvert.DeserializeObject<List<YiimpBlock>>(results);
      return blocks;
    }
    public async Task<List<YiimpMiner>> Miners() {
      List<YiimpMiner> miners = new List<YiimpMiner>();
      string command = string.Format("miners");
      string results = await FetchData(command);
      miners = JsonConvert.DeserializeObject<List<YiimpMiner>>(results);
      return miners;
    }
  }
}