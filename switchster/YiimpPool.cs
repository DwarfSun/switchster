using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class YiimpPool {
    protected YiimpServerDetails details;
    protected YiimpQueryAPI api;
    public YiimpWallet wallet = new YiimpWallet();
    public Dictionary<string, YiimpStatus> statuses = new Dictionary<string, YiimpStatus>();
    public Dictionary<string, YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
    protected Thread walletThread;
    protected Thread statusesThread;
    protected Thread currenciesThread;
    
    public YiimpPool(YiimpServerDetails _details) {
      details = _details;
      api = new YiimpQueryAPI(details.apiUrl);
      walletThread = new Thread(WalletRefresher);
      walletThread.Start();
      statusesThread = new Thread(StatusesRefresher);
      statusesThread.Start();
      currenciesThread = new Thread(CurrenciesRefresher);
      currenciesThread.Start();
    }
    protected void WalletRefresher() {
      do {
        try {
          wallet = api.WalletStatus(details.walletId).Result;
          Thread.Sleep(Switchster.WALLET_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh balance data for {0}. Retrying in {1} seconds.", details.name, Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
    protected void StatusesRefresher() {
      do {
        try {
          Dictionary<string, YiimpStatus> s = api.PoolStatus().Result;
          if (s.Count > 0) {
            statuses = s;
          }
          else {
            throw new Exception();
          }
          Thread.Sleep(Switchster.STATUSES_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh pool status data for {0}. Retrying in {1} seconds.", details.name, Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
    protected void CurrenciesRefresher(){
      do {
        try {
          Dictionary<string, YiimpCurrency> c = api.Currencies().Result;
          if (c.Count > 0) {
            currencies = c;
          }
          else {
            throw new Exception();
          }
          Thread.Sleep(Switchster.CURRENCIES_REFRESHER_DELAY);
        }
        catch (Exception e){
          System.Console.Error.WriteLine(e.Message);
          System.Console.Error.WriteLine("Failed to refresh currencies data for {0}. Retrying in {1} seconds.", details.name, Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
  }
}