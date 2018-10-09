using System.Collections.Generic;
using Newtonsoft.Json;

namespace switchster {
    public class YiimpWalletDetail : YiimpBalance {
        [JsonProperty("paidtotal")]
        public double paidtotal;
        [JsonProperty("miners")]
        List<YiimpWorker> miners;
        [JsonProperty("payouts")]
        List<YiimpTransaction> payouts;
    }
}