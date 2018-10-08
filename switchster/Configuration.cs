using System;
using Newtonsoft.Json;

namespace switchster
{
  public class Configuration {
    /* */
    public string yiimpWallet;
    public string yiimpCurrency;
    public string mphUsername;
    public string workerId;
    public bool donationsEnabled = true;

    /* */
    public Configuration(string configFile = "config.json") {}
    private void LoadConfigFile() {}
    private void SaveConfigFile() {}
  }
}