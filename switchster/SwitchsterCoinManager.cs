namespace switchster {
  public /*static*/ class SwitchsterCoinManager {

    public void BuildCoinList() {
    }

    private void LoadCoin(string _symbol) {
      SwitchsterCoin coin = new SwitchsterCoin{symbol = _symbol};
    }
  }
}