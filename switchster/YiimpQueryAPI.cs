using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class YiimpQueryAPI : QueryAPI {
    public YiimpQueryAPI(string _apiUrl = @"http://api.yiimp.eu/api/") {
      apiUrl = _apiUrl;
    }
    public async Task<YiimpWallet> WalletStatus(string wallet) {
      YiimpWallet walletSimple = new YiimpWallet();
      string command = string.Format("{0}wallet?address={1}", apiUrl, wallet);
      string results = await GetPublicDataJson(command);
      walletSimple = JsonConvert.DeserializeObject<YiimpWallet>(results);
      return walletSimple;
    }
    public async Task<Dictionary<string, YiimpStatus>> PoolStatus() {
      Dictionary<string, YiimpStatus> statuses = new Dictionary<string, YiimpStatus>();
      string command = string.Format("{0}status", apiUrl);
      string results = await GetPublicDataJson(command);
      statuses = JsonConvert.DeserializeObject<Dictionary<string, YiimpStatus>>(results);
      return statuses;
    }
    public async Task<Dictionary<string, YiimpCurrency>> Currencies() {
      Dictionary<string, YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
      string command = string.Format("{0}currencies", apiUrl);
      string results = await GetPublicDataJson(command);
      currencies = JsonConvert.DeserializeObject<Dictionary<string, YiimpCurrency>>(results);
      return currencies;
    }
  }
}