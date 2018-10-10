using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;
namespace switchster {
  public class ZergCurrency : YiimpCurrency {
    public double difficulty;

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
    public long mbtc_mh_factor;
    public int noautotrade;
    public long pool_ttf;
    public long real_ttf;
  }
}