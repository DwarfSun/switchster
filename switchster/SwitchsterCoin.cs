namespace switchster {
  public class SwitchsterCoin {
    public string symbol;
    public string name;
    public SwitchsterAlgorithm algorithm;
    public YiimpServerDetails serverDetails;
    public double fees;
    public double networkHashrate;
    public double blockReward;
    public double btcValue;
    public double blockTime;
/*      */
    public double SwitchsterProfitRank() {
      double rank = 0;
      rank = (algorithm.myHashrate / networkHashrate) * ((blockReward * btcValue * (fees * 0.01)) / blockTime);
      return rank;
    }
  }
}