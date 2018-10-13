using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class CoinGecko {
    public List<CoinGeckoCoin> CoinList = new List<CoinGeckoCoin>();
    //private CoinGeckoQueryAPI api = new CoinGeckoQueryAPI();
    Thread CoinListThread;
    public CoinGecko() {
      CoinListThread = new Thread(CoinListRefresher);
      CoinListThread.Start();
    }
    private void CoinListRefresher() {
      do {
        try {
          CoinList = new CoinGeckoQueryAPI().CoinList().Result;
          Thread.Sleep(Switchster.COINLIST_REFRESHER_DELAY);
        }
        catch (Exception e){
          System.Console.Error.WriteLine(e.Message);
          System.Console.Error.WriteLine(e.InnerException.Message);
          System.Console.Error.WriteLine("Failed to refresh coin list data for {0}. Retrying in {1} seconds.", "CoinGecko", Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }

  }
}