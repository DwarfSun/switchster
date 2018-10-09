using Newtonsoft.Json;
namespace switchster {
  public class YiimpStatus {
    [JsonProperty("name")]//:"aergo",
    public string name;
    [JsonProperty("port")]//:3691,
    public long port;
    [JsonProperty("coins")]//:1,
    public long coins;
    [JsonProperty("fees")]//:0.5,
    public double fees;
    [JsonProperty("hashrate")]//:116372311,
    public long hashrate;
    [JsonProperty("workers")]//:2,
    public long workers;
    [JsonProperty("estimate_current")]//:"0.00000976",
    private string _estimateCurrent;
    public double estimateCurrent {
      get {
        try {
          return double.Parse(_estimateCurrent);
        }
        catch {
          return 0;
        }
      }
    }
    [JsonProperty("estimate_last24h")]//:"0.00001120",
    private string _estimateLast24h;
    public double estimateLast24h {
      get {
        try {
          return double.Parse(_estimateLast24h);
        }
        catch {
          return 0;
        }
      }
    }
    [JsonProperty("actual_last24h")]//:"0.00934",
    private string _actualLast24h;
    public double actualLast24h {
      get {
        try {
          return double.Parse(_actualLast24h);
        }
        catch {
          return 0;
        }
      }
    }
    [JsonProperty("mbtc_mh_factor")]//:1,
    public long mBtcMhFactor;
    [JsonProperty("hashrate_last24h")]//:101527438}
    public long hashrateLast24h;
  }
}
