namespace switchster {
  public class YiimpServerDetails {
    public string name;
    public string apiUrl;
    public string walletId;
    public string currency;

    public YiimpServerDetails(
        string _name = "ZergPool",
        string _apiUrl = "http://api.zergpool.com:8080/api/",
        string _walletId = "LdcpZkdLCJz6ifsmngzxwc4yWJgAbhKCW5",
        string _currency = "LTC"
      ) {
      name = _name;
      apiUrl = _apiUrl;
      walletId = _walletId;
      currency = _currency;
    }
  }
}