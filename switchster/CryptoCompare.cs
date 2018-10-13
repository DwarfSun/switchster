using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class CryptoCompare {
    public Dictionary<string, CryptoCompareCoin> CoinList = new Dictionary<string, CryptoCompareCoin>();
    public Dictionary<string, CryptoCompareCoinInfo> CoinsInfo = new Dictionary<string, CryptoCompareCoinInfo>();
    private CryptoCompareQueryAPI api = new CryptoCompareQueryAPI();
    Thread CoinListThread;
    Thread CoinInfoThread;
    public CryptoCompare() {
      CoinListThread = new Thread(CoinListRefresher);
      CoinListThread.Start();
    }

    private void CoinListRefresher() {
      do {
        try {
          CoinList = new CryptoCompareQueryAPI().CoinList().Result;
          Thread.Sleep(Switchster.COINLIST_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh coin list data for {0}. Retrying in {1} seconds.", "CryptoCompare", Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }

  }
}