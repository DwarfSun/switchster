using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class ZergQueryAPI : YiimpQueryAPI {
    public ZergQueryAPI(string _apiUrl = @"http://api.zergpool.com:8080/api/") {
      apiUrl = _apiUrl;
    } 
    public new async Task<Dictionary<string, ZergCurrency>> Currencies() {
      Dictionary<string, ZergCurrency> currencies = new Dictionary<string, ZergCurrency>();
      string command = string.Format("{0}currencies", apiUrl);
      string results = await GetPublicDataJson(command);
      currencies = JsonConvert.DeserializeObject<Dictionary<string, ZergCurrency>>(results);
      return currencies;
    }
    public async Task<ZergWalletDetail> WalletDetail(string wallet) {
      ZergWalletDetail walletDetail = new ZergWalletDetail();
      string command = string.Format("{0}walletEx?address={1}", apiUrl, wallet);
      string results = await GetPublicDataJson(command);
      walletDetail = JsonConvert.DeserializeObject<ZergWalletDetail>(results);
      return walletDetail;
    }
    public async Task<List<ZergBlock>> Blocks() {
      List<ZergBlock> blocks = new List<ZergBlock>();
      string command = string.Format("{0}blocks", apiUrl);
      string results = await GetPublicDataJson(command);
      blocks = JsonConvert.DeserializeObject<List<ZergBlock>>(results);
      return blocks;
    }
    public async Task<List<ZergMiner>> Miners() {
      List<ZergMiner> miners = new List<ZergMiner>();
      string command = string.Format("{0}miners", apiUrl);
      string results = await GetPublicDataJson(command);
      miners = JsonConvert.DeserializeObject<List<ZergMiner>>(results);
      return miners;
    }
  }
}