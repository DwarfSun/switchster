using Newtonsoft.Json;

namespace switchster {
    public class YiimpBalance {
        [JsonProperty("unsold")]//: 0, 
        public double unsold;
        [JsonProperty("balance")]//: 0.00795237,
        public double balance;
        [JsonProperty("unpaid")]//: 0.00795237, 
        public double unpaid;
        [JsonProperty("paid24h")]//: 0.00000000, 
        public double paid24h;
        [JsonProperty("total")]//: 0.00795237
        public double total;
    }
}