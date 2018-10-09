using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;
namespace switchster {
  public class YiimpBlock {
      [JsonProperty("symbol")]//:"SCS",
      public string symbol;
      [JsonProperty("time")]//:"1539058661",
      public string time;
      public long Time {
        get {
          long t = 0;
          try {
            t = long.Parse(time);
          }
          catch {}
          return t;
        }
      }
      [JsonProperty("height")]//:"642329",
      public string height;
      [JsonProperty("amount")]//:null,
      public string amount;
      [JsonProperty("category")]//:"new",
      public string category;
      [JsonProperty("difficulty")]//:"390.107427",
      public string difficulty;
      [JsonProperty("difficulty_user")]//:"405.022422",
      public string difficultyUser;
      [JsonProperty("algo")]//:"x13"
      public string algo;
  }
}