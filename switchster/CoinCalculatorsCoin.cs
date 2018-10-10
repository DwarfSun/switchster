using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;

namespace switchster {
  public class CoinCalculatorsCoin {

    [JsonProperty("name")]//: "Zero",
    public string name;

    [JsonProperty("algorithm")]//: "Equihash(192,7)",
    public string algorithm;

    [JsonProperty("image")]//: "images/coin/zer.png",
    public string imageUrl;

    [JsonProperty("blockTime")]//: 119.0,
    public double? blockTime;

    [JsonProperty("blockReward")]//: 10.0,
    public double? blockReward;

    [JsonProperty("lastBlock")]//: 430113.0,
    public double? lastBlock;

    [JsonProperty("price_usd")]//: 0.1533938812,
    public double? priceUsd;

    [JsonProperty("price_btc")]//: 2.345E-05,
    public double? priceBtc;

    [JsonProperty("highestBid")]//: 0.0,
    public double? highestBid;

    [JsonProperty("lowestAsk")]//: 0.0,
    public double? lowestAsk;

    [JsonProperty("volume_usd")]//: 3878.25193812,
    public double? volumeUsd;

    [JsonProperty("totalSupply")]//: 4090385.0,
    public double? totalSupply;

    [JsonProperty("marketCapUSD")]//: 627440.0,
    public double? marketCapUSD;

    [JsonProperty("percentChange_1h")]//: 0.0,
    public double? percentChange1h;

    [JsonProperty("percentChange_24h")]//: -10.08,
    public double? percentChange24h;

    [JsonProperty("percentChange_7d")]//: 0.0,
    public double? percentChange7d;

    [JsonProperty("symbol")]//: "ZER",
    public string symbol;

    [JsonProperty("nethash24")]//: 47889.662303711804,
    public double? nethash24;

    [JsonProperty("nethash6")]//: 47495.804274638787,
    public double? nethash6;

    [JsonProperty("nethash3")]//: 43168.622677832645,
    public double? nethash3;

    [JsonProperty("currentNethash")]//: 58213.947617554288,
    public double? currentNethash;

    [JsonProperty("difficulty24")]//: 220429.76433632182,
    public double? difficulty24;

    [JsonProperty("difficulty6")]//: 207290.62276714781,
    public double? difficulty6;

    [JsonProperty("difficulty3")]//: 211309.91594466506,
    public double? difficulty3;

    [JsonProperty("currentDifficulty")]//: 216483.11770278,
    public double? currentDifficulty;

    [JsonProperty("powerWatt")]//: 0.0,
    public double? powerWatt;

    [JsonProperty("kWhPriceUSD")]//: 0.0,
    public double? kWhPriceUSD;

    [JsonProperty("rewardsInHour")]//: 6.3170420055334935,
    public double? rewardsInHour;

    [JsonProperty("rewardsInDay")]//: 151.60900813280384,
    public double? rewardsInDay;

    [JsonProperty("rewardsInWeek")]//: 1061.2630569296268,
    public double? rewardsInWeek;

    [JsonProperty("rewardsInMonth")]//: 4548.270243984115,
    public double? rewardsInMonth;

    [JsonProperty("rewardsInYear")]//: 55337.2879684734,
    public double? rewardsInYear;

    [JsonProperty("revenueInHourUSD")]//: 0.96899559093221443,
    public double? revenueInHourUSD;

    [JsonProperty("revenueInDayUSD")]//: 23.255894182373144,
    public double? revenueInDayUSD;

    [JsonProperty("revenueInWeekUSD")]//: 162.791259276612,
    public double? revenueInWeekUSD;

    [JsonProperty("revenueInMonthUSD")]//: 697.67682547119432,
    public double? revenueInMonthUSD;

    [JsonProperty("revenueInYearUSD")]//: 8488.4013765661985,
    public double? revenueInYearUSD;

    [JsonProperty("profitInHourUSD")]//: 0.96899559093221443,
    public double? profitInHourUSD;

    [JsonProperty("profitInDayUSD")]//: 23.255894182373147,
    public double? profitInDayUSD;

    [JsonProperty("profitInWeekUSD")]//: 162.79125927661204,
    public double? profitInWeekUSD;

    [JsonProperty("profitInMonthUSD")]//: 697.67682547119443,
    public double? profitInMonthUSD;

    [JsonProperty("profitInYearUSD")]//: 8488.4013765661985,
    public double? profitInYearUSD;

    [JsonProperty("yourHashrate")]//: 1000.0,
    public double? yourHashrate;

    [JsonProperty("deactive")]//: false,
    public bool deactive;

    [JsonProperty("lastUpdate")]//: 1539179473979
    public long lastUpdate;

  }
}