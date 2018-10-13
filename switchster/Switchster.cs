using System.Collections.Generic;
namespace switchster {
  public static class Switchster {
    public const int SECOND = 1000;
    public const int MINUTE = 60 * SECOND;
    public const int HOUR = 60 * MINUTE;
    public const int DAY = 24 * HOUR;
    public const int COINLIST_REFRESHER_DELAY = 10 * MINUTE;
    public const int WALLET_REFRESHER_DELAY = 30 * MINUTE;
    public const int STATUSES_REFRESHER_DELAY = HOUR;
    public const int CURRENCIES_REFRESHER_DELAY = 5 * MINUTE;
    public const int MINERS_REFRESHER_DELAY = 1 * DAY;
    public const int WALLET_DETAIL_REFRESHER_DELAY = 30 * MINUTE;
    public const int RETRY_DELAY = 30 * SECOND;    
    public static bool ALIVE = true;
    public static int PoolCoinsCount {
      get {
        int total = 0;
        foreach(KeyValuePair<string, YiimpPool> pool in pools){
          total += pool.Value.currencies.Count;
        }
        return total;
      }
    }
/*      */
    public static Dictionary<string, YiimpPool> pools = new Dictionary<string, YiimpPool>();
    public static CoinCalculators coinCalculators = new CoinCalculators();
    public static CryptoCompare cryptoCompare = new CryptoCompare();
    public static CoinGecko coinGecko = new CoinGecko();
  }
}