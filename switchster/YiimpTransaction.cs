using Newtonsoft.Json;
namespace switchster {
  public class YiimpTransaction {
      [JsonProperty("time")]//: "1529749163",
      private string _time;
      public long Time {
          get {
              try {
                  return long.Parse(_time);
              }
              catch {
                  return 0;
              }
          }
      }
      [JsonProperty("amount")]//: 0.01714574,
      public double amount;
      [JsonProperty("tx")]//: "8a727e1b591034ad6bdea8be2d82849e8eeaeaf3427414c92327a77c9c56b667"
      public string tx;
  }
}