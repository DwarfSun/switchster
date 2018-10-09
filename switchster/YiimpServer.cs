using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class YiimpServer {
    const int SECOND = 1000;
    const int MINUTE = 60 * SECOND;
    const int HOUR = 60 * MINUTE;
    const int DAY = 24 * HOUR;
    const int STATUSES_REFRESHER_DELAY = HOUR;
    const int CURRENCIES_REFRESHER_DELAY = 5 * MINUTE;
    const int MINERS_REFRESHER_DELAY = 1 * DAY;
    const int WALLET_DETAIL_REFRESHER_DELAY = 30 * MINUTE;
    const int RETRY_DELAY = 30 * SECOND;
    private YiimpServerDetails details;
    private YiimpQueryAPI api;
    public YiimpWalletDetail walletDetail = new YiimpWalletDetail();
    public Dictionary<string, YiimpStatus> statuses = new Dictionary<string, YiimpStatus>();
    public Dictionary<string, YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
    public List<YiimpBlock> blocks = new List<YiimpBlock>();
    public List<YiimpMiner> miners = new List<YiimpMiner>();

    Thread walletDetailsThread;
    Thread statusesThread;
    Thread currenciesThread;
    Thread blocksThread;
    Thread minersThread;
    
    public YiimpServer(YiimpServerDetails _details) {
      details = _details;
      api = new YiimpQueryAPI(details.apiUrl);
      walletDetailsThread = new Thread(WalletDetailsRefresher);
      walletDetailsThread.Start();
      statusesThread = new Thread(StatusesRefresher);
      statusesThread.Start();
      currenciesThread = new Thread(CurrenciesRefresher);
      currenciesThread.Start();
      blocksThread = new Thread(BlocksRefresher);
      blocksThread.Start();
      minersThread = new Thread(MinersRefresher);
      minersThread.Start();
    }
    private void WalletDetailsRefresher() {
      do {
        try {
          walletDetail = api.WalletDetail(details.walletId).Result;
          Thread.Sleep(WALLET_DETAIL_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh transaction data for {0}. Retrying in {1} seconds.", details.name, RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }

    private void StatusesRefresher() {
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
    private void CurrenciesRefresher(){
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
        catch {
          System.Console.Error.WriteLine("Failed to refresh currencies data for {0}. Retrying in {1} seconds.", details.name, RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
    private void BlocksRefresher(){
      int BLOCK_REFRESHER_DELAY = RETRY_DELAY;
      do {
        try {
          List<YiimpBlock> b = api.Blocks().Result;
          if (b.Count > 0) {
            blocks = b;
            BLOCK_REFRESHER_DELAY = SECOND * (int)((blocks[0].Time - blocks[blocks.Count-1].Time)*0.5);
            System.Console.WriteLine ("BLOCK_REFESHER_DELAY={0} sec.", BLOCK_REFRESHER_DELAY/SECOND);
          }
          else {
            throw new Exception();
          }
          Thread.Sleep(BLOCK_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh blocks data for {0}. Retrying in {1} seconds.", details.name, RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
    private void MinersRefresher(){
      do {
        try {
          List<YiimpMiner> m = api.Miners().Result;
          if (m.Count > 0){
            miners=m;
          }
          else {
            throw new Exception();
          }
          Thread.Sleep(MINERS_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh miners data for {0}. Retrying in {1} seconds.", details.name, RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
  }
}