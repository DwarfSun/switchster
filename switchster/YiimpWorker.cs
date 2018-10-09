using Newtonsoft.Json;
namespace switchster {
  public class YiimpWorker : YiimpMiner {
    [JsonProperty("password")]//: "d=96",
    public string password;
		[JsonProperty("ID")]//: "",
    public string id;
		[JsonProperty("difficulty")]//: 96,
    public long difficulty;
		[JsonProperty("subscribe")]//: 1,
    public long subscribe;
		[JsonProperty("accepted")]//: 82463372.083,
    public double accepted;
		[JsonProperty("rejected")]//: 0
    public double rejected;
    public new string count {
      get {
        return "1";
      }
      set {
        count = "1";
      }
    }
  }
}