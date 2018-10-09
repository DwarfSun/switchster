using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class CryptoCompare {
    const int SECOND = 1000;
    const int MINUTE = 60 * SECOND;
    const int HOUR = 60 * MINUTE;
    const int DAY = 24 * HOUR;
    const int COINLIST_REFRESHER_DELAY = 10 * MINUTE;
    const int RETRY_DELAY = 30 * SECOND;
    public Dictionary<string, CryptoCompareCoin> CoinList = new Dictionary<string, CryptoCompareCoin>();
    private CryptoCompareQueryAPI api = new CryptoCompareQueryAPI();
    Thread CoinListThread;
    public CryptoCompare() {
      CoinListThread = new Thread(CoinListRefresher);
      CoinListThread.Start();
    }

    private void CoinListRefresher() {
      do {
        try {
          CoinList = new CryptoCompareQueryAPI().CoinList().Result;
          Thread.Sleep(COINLIST_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh coin list data for {0}. Retrying in {1} seconds.", "CryptoCompare", RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }

  }
}