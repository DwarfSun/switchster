using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;
namespace switchster {
  public class YiimpCurrency {
    public string algo;
    public long port;
    public string name;
    public long height;
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
    public double estimate;
    [JsonProperty("24h_blocks")] public long _24h_blocks;
    [JsonProperty("24h_btc")] public double _24h_btc;
    public long lastblock;
    public long timesincelast;
  }
}