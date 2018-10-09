using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;

namespace switchster {
    public class CryptoCompareCoin {
        [JsonProperty("Id")]
        public string id;
        [JsonProperty("Url")]
        public string url;
        [JsonProperty("ImageUrl")]
        public string imageUrl;
        [JsonProperty("Name")]
        public string name;
        [JsonProperty("Symbol")]
        public string symbol;
        [JsonProperty("CoinName")]
        public string coinName;
        [JsonProperty("FullName")]
        public string fullName;
        [JsonProperty("Algorithm")]
        public string algorithm;
        [JsonProperty("ProofType")]
        public string proofType;
        [JsonProperty("FullyPremined")]
        public string fullyPremined;
        [JsonProperty("TotalCoinSupply")]
        public string totalCoinsSupply;
        [JsonProperty("BuiltOn")]
        public string builtOn;
        [JsonProperty("SmartContractAddress")]
        public string smartContractAddress;
        [JsonProperty("PreMinedValue")]
        public string preMinedValue;
        [JsonProperty("TotalCoinsFreeFloat")]
        public string totalCoinsFreeFloat;
        [JsonProperty("SortOrder")]
        public string sortOrder;
        [JsonProperty("Sponsored")]
        public bool sponsored;
        [JsonProperty("IsTrading")]
        public bool isTrading;
    }
}