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
      ZergServer zergpool = new ZergServer(new YiimpServerDetails{
        name = "ZergPool.com",
        apiUrl = "http://api.zergpool.com:8080/api/"
      });
      YiimpServer yiimpEu = new YiimpServer(new YiimpServerDetails{
        name = "Yiimp.EU",
        apiUrl = "http://api.yiimp.eu/api/"
      });

      CryptoCompare cc = new CryptoCompare();
      Console.WriteLine("BAL: {0} / {1} :TOT", zergpool.wallet.balance, zergpool.wallet.total);
/**/
      int fails = 0;
      while (zergpool.currencies.Count < 1 || cc.CoinList.Count < 1) {
        Thread.Sleep(2500);
        //System.Console.Write(".");
      }
      //System.Console.WriteLine("Yiimp.EU supports {0} coins", yiimpEu.currencies.Count);

      foreach(KeyValuePair<string, YiimpCurrency> c in zergpool.currencies) {
        CryptoCompareCoin coin = new CryptoCompareCoin();
        Console.Write("{0} ", c.Key);
        try {
          string code = c.Key;
          if (code.Contains("-")) {
            code = code.Split("-")[0];
          }
          coin = cc.CoinList[code];
          System.Console.WriteLine(coin.coinName);
        } catch {
          System.Console.WriteLine("-No data- {0} {1} {2}", c.Key, c.Value.name, c.Value.algo);
          fails++;
        }
      }
      System.Console.WriteLine("Failures: {0}", fails);
 /* */
      /*
      foreach(KeyValuePair<string, YiimpCurrency> c in zergpool.currencies) {
        Console.WriteLine("{0}\t{1}\t{2}\t", c.Key, c.Value.name, c.Value.NetworkHashrate);
      }
      Console.WriteLine(zergpool.currencies.Count);
      *//*
      foreach(KeyValuePair<string, CryptoCompareCoin> c in cc.CoinList) {
        if (c.Key == "XMR")
          Console.WriteLine("{0}\t{1}\t{2}\t{3}", c.Key, c.Value.symbol, c.Value.id, c.Value.isTrading);
      }
      Console.WriteLine(cc.CoinList.Count);
      */
    }
  }
}
