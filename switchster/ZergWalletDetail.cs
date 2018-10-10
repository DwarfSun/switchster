using System.Collections.Generic;
using Newtonsoft.Json;

namespace switchster {
    public class ZergWalletDetail : YiimpBalance {
        [JsonProperty("paidtotal")]
        public double paidtotal;
        [JsonProperty("miners")]
        List<ZergWorker> miners;
        [JsonProperty("payouts")]
        List<ZergTransaction> payouts;
    }
}