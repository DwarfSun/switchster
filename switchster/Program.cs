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
      Dictionary<string, YiimpServer> servers = new Dictionary<string, YiimpServer>();
      /* */
      servers.Add("zergpool", new ZergServer(new YiimpServerDetails{
        name = "ZergPool.com",
        apiUrl = "http://api.zergpool.com:8080/api/"
      }));
      /* */
      servers.Add("yiimpEu", new YiimpServer(new YiimpServerDetails{
        name = "Yiimp.EU",
        apiUrl = "http://api.yiimp.eu/api/"
      }));
      /* */
      CoinCalculators coinCalculators = new CoinCalculators();
      CryptoCompare cryptoCompare = new CryptoCompare();
      CoinGecko coinGecko = new CoinGecko();
      bool populated = true;
      do {
        Thread.Sleep(5000);
        populated = true;
        foreach(KeyValuePair<string, YiimpServer> server in servers) {
          if (server.Value.currencies.Count < 1) populated = false;
        }
      } while (cryptoCompare.CoinList.Count < 1 || coinGecko.CoinList.Count < 1 || !populated);
      
      foreach(KeyValuePair<string,YiimpServer> s in servers){
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
          if (coinCalculators.CoinList.FindIndex(item => item.symbol.ToUpper() == c.Key.ToUpper()) >= 0){
            System.Console.WriteLine("{0}/CoinCalculators match for {1}", s.Key, c.Key);
            matches++;
          }
          else if (coinCalculators.GetCoin(c.Value.name) != null ){
            coinCalculators.CoinList.Add(CoinCalculatorsQueryAPI.lastCoin);
            System.Console.WriteLine("{0}/CoinCalculators(specific) match for {1}", s.Key, c.Key);
            matches++;
          }/* */
          else if(coinGecko.CoinList.FindIndex(item => item.symbol.ToUpper() == c.Key.ToUpper()) >= 0){
            System.Console.WriteLine("{0}/CoinGecko match for {1}", s.Key, c.Key);
            matches++;
          }/* */
          else if(cryptoCompare.CoinList.ContainsKey(c.Key.ToUpper())) {
            System.Console.WriteLine("{0}/CryptoCompare match for {1}", s.Key, c.Key);
            matches++;
          }/* */
          else {
            System.Console.WriteLine("No match for {1}", s.Key, c.Key);
          }
        }
        System.Console.WriteLine("{0}/{1} matches.\n", matches, currencies.Count);
      }
/*
      do {
        Thread.Sleep(5000);
        foreach(KeyValuePair<string, YiimpServer> server in servers) {
          System.Console.WriteLine("{0} supports {1} currencies:", server.Key, server.Value.currencies.Count);
          if(server.Value is ZergServer) {
            System.Console.WriteLine("Zerg style server with balance of {0}", ((ZergServer)server.Value).walletDetail.balance);
          }
        }
      } while (Switchster.ALIVE);
*/
    }
  }
}
