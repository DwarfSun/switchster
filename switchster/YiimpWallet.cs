using Newtonsoft.Json;

namespace switchster {
    public class YiimpWallet : YiimpBalance {
        [JsonProperty("currency")]//: "LTC",
        public string currency;
    }
}