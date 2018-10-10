using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class CoinGecko {
    const int SECOND = 1000;
    const int MINUTE = 60 * SECOND;
    const int HOUR = 60 * MINUTE;
    const int DAY = 24 * HOUR;
    const int COINLIST_REFRESHER_DELAY = 10 * MINUTE;
    const int RETRY_DELAY = 30 * SECOND;
    public List<CoinGeckoCoin> CoinList = new List<CoinGeckoCoin>();
    private CoinGeckoQueryAPI api = new CoinGeckoQueryAPI();
    Thread CoinListThread;
    public CoinGecko() {
      CoinListThread = new Thread(CoinListRefresher);
      CoinListThread.Start();
    }

    private void CoinListRefresher() {
      do {
        try {
          CoinList = new CoinGeckoQueryAPI().CoinList().Result;
          Thread.Sleep(COINLIST_REFRESHER_DELAY);
        }
        catch (Exception e){
          System.Console.Error.WriteLine(e.Message);
          System.Console.Error.WriteLine(e.InnerException.Message);
          System.Console.Error.WriteLine("Failed to refresh coin list data for {0}. Retrying in {1} seconds.", "CoinGecko", RETRY_DELAY/SECOND);
          Thread.Sleep(RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }

  }
}