using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;
namespace switchster {
  public class YiimpCurrency {
    public string algo;
    public long port;
    public string name;
    public long height;
    public double difficulty;
    public long workers;
    public long shares;
    [JsonProperty("hashrate")] 
    public string hashrate;
    public BigInteger Hashrate {
      get {
        BigInteger result = new BigInteger();
        BigInteger.TryParse(hashrate, System.Globalization.NumberStyles.Float | NumberStyles.AllowExponent | NumberStyles.Integer, new NumberFormatInfo(),  out result);
        return result;
      }
    }
    [JsonProperty("network_hashrate")] 
    public string network_hashrate;
    public BigInteger NetworkHashrate {
      get {
        BigInteger result = new BigInteger();
        BigInteger.TryParse(network_hashrate, System.Globalization.NumberStyles.Float | NumberStyles.AllowExponent | NumberStyles.Integer, new NumberFormatInfo(),  out result);
        return result;
      }
    }
    public double reward;
    public double estimate;
    public long mbtc_mh_factor;
    [JsonProperty("24h_blocks")] public long _24h_blocks;
    [JsonProperty("24h_btc")] public double _24h_btc;
    public long lastblock;
    public long timesincelast;
    public int noautotrade;
    public long pool_ttf;
    public long real_ttf;
  }
}