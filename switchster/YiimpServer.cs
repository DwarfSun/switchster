using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class YiimpServer {
    protected const int SECOND = 1000;
    protected const int MINUTE = 60 * SECOND;
    protected const int HOUR = 60 * MINUTE;
    protected const int DAY = 24 * HOUR;
    protected const int WALLET_REFRESHER_DELAY = 30 * MINUTE;
    protected const int STATUSES_REFRESHER_DELAY = HOUR;
    protected const int CURRENCIES_REFRESHER_DELAY = 5 * MINUTE;
    protected const int RETRY_DELAY = 30 * SECOND;
    protected YiimpServerDetails details;
    protected YiimpQueryAPI api;
    public YiimpWallet wallet = new YiimpWallet();
    public Dictionary<string, YiimpStatus> statuses = new Dictionary<string, YiimpStatus>();
    public Dictionary<string, YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
    protected Thread walletThread;
    protected Thread statusesThread;
    protected Thread currenciesThread;
    
    public YiimpServer(YiimpServerDetails _details) {
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
          Thread.Sleep(WALLET_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh balance data for {0}. Retrying in {1} seconds.", details.name, RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
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
          Thread.Sleep(STATUSES_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh pool status data for {0}. Retrying in {1} seconds.", details.name, RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
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
          Thread.Sleep(CURRENCIES_REFRESHER_DELAY);
        }
        catch (Exception e){
          System.Console.Error.WriteLine(e.Message);
          System.Console.Error.WriteLine("Failed to refresh currencies data for {0}. Retrying in {1} seconds.", details.name, RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
  }
}