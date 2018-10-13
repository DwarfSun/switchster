using System;
using System.Collections.Generic;
using System.Threading;

namespace switchster
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Switchster v0.01 (BETA)");
      /* */
      Switchster.pools.Add("zergpool", new ZergPool(new YiimpServerDetails{
        name = "ZergPool.com",
        apiUrl = "http://api.zergpool.com:8080/api/",
        miningUrl = "{0}.mine.zergpool.com"
      }));
      /* */
      Switchster.pools.Add("yiimpEu", new YiimpPool(new YiimpServerDetails{
        name = "Yiimp.EU",
        apiUrl = "http://api.yiimp.eu/api/",
        miningUrl = "yiimp.eu"
      }));
      /* */

      bool populated = true;
      do {
        Thread.Sleep(5000);
        populated = true;
        foreach(KeyValuePair<string, YiimpPool> server in Switchster.pools) {
          if (server.Value.currencies.Count < 1) populated = false;
        }
      } while (Switchster.cryptoCompare.CoinList.Count < 1 || Switchster.coinGecko.CoinList.Count < 1 || !populated);
      
      foreach(KeyValuePair<string,YiimpPool> s in Switchster.pools){
        Dictionary<string,YiimpCurrency> currencies = new Dictionary<string, YiimpCurrency>();
        foreach(KeyValuePair<string, YiimpCurrency> c in s.Value.currencies){
          if(c.Key.Contains("-")){
          }
          else {
            currencies.Add(c.Key, c.Value);
          }
        }
        int matches = 0;
        foreach(KeyValuePair<string, YiimpCurrency> c in currencies){
          if (Switchster.coinCalculators.CoinList.FindIndex(item => item.symbol.ToUpper() == c.Key.ToUpper()) >= 0){
            System.Console.WriteLine("{0}/CoinCalculators match for {1}", s.Key, c.Key);
            matches++;
          }
          else if (Switchster.coinCalculators.GetCoin(c.Value.name) != null ){
            Switchster.coinCalculators.CoinList.Add(CoinCalculatorsQueryAPI.lastCoin);
            System.Console.WriteLine("{0}/CoinCalculators(specific) match for {1}", s.Key, c.Key);
            matches++;
          }/* */
          else if(Switchster.coinGecko.CoinList.FindIndex(item => item.symbol.ToUpper() == c.Key.ToUpper()) >= 0){
            System.Console.WriteLine("{0}/CoinGecko match for {1}", s.Key, c.Key);
            matches++;
          }/* */
          else if(Switchster.cryptoCompare.CoinList.ContainsKey(c.Key.ToUpper())) {
            System.Console.WriteLine("{0}/CryptoCompare match for {1}", s.Key, c.Key);
            matches++;
          }/* */
          else {
            System.Console.WriteLine("No match for {1}", s.Key, c.Key);
          }
        }
        System.Console.WriteLine("{0}/{1} matches.\n", matches, currencies.Count);
      }
    }
  }
}
