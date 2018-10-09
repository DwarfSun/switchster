using Newtonsoft.Json;
namespace switchster {
    public class YiimpMiner {
        [JsonProperty("algo")]//:"bcd",
        public string algo;
        [JsonProperty("version")]//:"t-rex\/0.6.10",
        public string version;
        [JsonProperty("count")]//:"648"}
        public string count;

        public string name {
            get {
                try {
                    string[] r = version.Split(@"\/");
                    return r[0];
                }
                catch {
                    return "";
                }
            }
        }
        public string ver {
            get {
                try {
                    string[] r = version.Split(@"\/");
                    return r[r.Length-1];
                }
                catch {
                    return "";
                }
            }
        }
        public int Count {
            get {
                try {
                    return int.Parse(count);
                }
                catch {
                    return 0;
                }
            }
        }
    }
}