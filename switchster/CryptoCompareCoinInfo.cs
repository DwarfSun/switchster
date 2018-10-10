using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;

namespace switchster {
    public class CryptoCompareCoinInfo {
        [JsonProperty("Id")]//:"1182",
        public string id;
        [JsonProperty("Name")]//:"BTC",
        public string symbol;
        [JsonProperty("FullName")]//:"Bitcoin",
        public string name;
        //"Internal":"BTC",
        [JsonProperty("ImageUrl")]//:"/media/19633/btc.png",
        public string imageUrl;
        //"Url":"/coins/btc/overview",
        [JsonProperty("Algorithm")]//:"SHA256",
        public string algorithm;
        //"ProofType":"PoW",
        [JsonProperty("NetHashesPerSecond")]//:53365558522.1254,
        public double NetworkHashrate;
        //"BlockNumber":545194,
        [JsonProperty("BlockTime")]//:600,
        public int blockTime;
        [JsonProperty("BlockReward")]//:12.5,
        public double blockReward;
        //"Type":1,
        //"DocumentType":"Webpagecoinp"
    }
    public class CryptoCompareConversionInfo {
        //"Conversion":"direct",
        [JsonProperty("Conversion")]
        public string conversion;
        //"ConversionSymbol":"",
        //"CurrencyFrom":"BTC",
        //"CurrencyTo":"USD",
        //"Market":"CCCAGG",
        //"Supply":17314937,
        //"TotalVolume24H":210220.02416421805,
        //"SubBase":"5~",
        //"SubsNeeded":["5~CCCAGG~BTC~USD"],
        [JsonProperty("RAW")]
        List<string> raw;        
    }
    public class CryptoCompareGeneralInfo {
        [JsonProperty("CoinInfo")]
        public CryptoCompareCoinInfo coinInfo;
        //ConversionInfo
        [JsonProperty("ConversionInfo")]
        public CryptoCompareConversionInfo conversionInfo;
    }
}