using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;

namespace switchster {
    public class CoinGeckoROI {
      [JsonProperty("times")]
      public double? times;
      [JsonProperty("currency")]
      public string currency;
      [JsonProperty("percentage")]
      public double? percentage;
    }
    public class CoinGeckoCoin {
        [JsonProperty("id")]
        public string id;
        [JsonProperty("symbol")]
        public string symbol;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("image")]
        public string imageUrl;
        [JsonProperty("current_price")]
        public double? currentPrice;
        [JsonProperty("market_cap")]
        public double? marketCap;
        [JsonProperty("market_cap_rank")]
        public long? marketCapRank;
        [JsonProperty("total_volume")]
        public double? totalVolume;
        [JsonProperty("high_24h")]
        public double? high24h;
        [JsonProperty("low_24h")]
        public double? low24h;
        [JsonProperty("price_change_24h")]
        public double? priceChange24h;
        [JsonProperty("price_change_percentage_24h")]
        public double? priceChangePercentage24h;
        [JsonProperty("market_cap_change_24h")]
        public double? marketCapChange24h;
        [JsonProperty("market_cap_change_percentage_24h")]
        public string marketCapChangePercentage24h;
        [JsonProperty("circulating_supply")]
        public string circulatingSupply;
        [JsonProperty("total_supply")]
        public double? totalSupply;
        [JsonProperty("ath")]
        public double? ath;
        [JsonProperty("ath_change_percentage")]
        public double? athChangePercentage;
        [JsonProperty("ath_date")]
        public string athDate;
        [JsonProperty("roi")]
        public CoinGeckoROI roi;
        [JsonProperty("last_updated")]
        public string lastUpdated;
    }
}