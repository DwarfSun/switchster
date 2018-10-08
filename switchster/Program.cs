using System;
using System.Collections.Generic;

namespace switchster
{
  class Program
  {
    static void Main(string[] args)
    {
      YiimpServer zergpool = new YiimpServer();
      Console.WriteLine("Switchster (v0.01)");
      foreach(KeyValuePair<string, YiimpCurrency> c in zergpool.currencies) {
        Console.WriteLine("{0}\t{1}\t{2}\t", c.Key, c.Value.name, c.Value.NetworkHashrate);
      }
      Console.WriteLine(zergpool.currencies.Count);
    }
  }
}
