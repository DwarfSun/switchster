using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace switchster {
  public class ZergPool : YiimpPool {
    protected new ZergQueryAPI api;
    public ZergWalletDetail walletDetail = new ZergWalletDetail();
    public List<ZergBlock> blocks = new List<ZergBlock>();
    public List<ZergMiner> miners = new List<ZergMiner>();
    Thread walletDetailsThread;
    Thread blocksThread;
    Thread minersThread;
/*  */
    public ZergPool(YiimpServerDetails _details) : base(_details) {
      api = new ZergQueryAPI(details.apiUrl);
      walletDetailsThread = new Thread(WalletDetailsRefresher);
      walletDetailsThread.Start();
      blocksThread = new Thread(BlocksRefresher);
      blocksThread.Start();
      minersThread = new Thread(MinersRefresher);
      minersThread.Start();
    }
    private void WalletDetailsRefresher() {
      do {
        try {
          walletDetail = api.WalletDetail(details.walletId).Result;
          Thread.Sleep(Switchster.WALLET_DETAIL_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh transaction data for {0}. Retrying in {1} seconds.", details.name, Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
    private void BlocksRefresher(){
      int BLOCK_REFRESHER_DELAY = Switchster.RETRY_DELAY;
      do {
        try {
          List<ZergBlock> b = api.Blocks().Result;
          if (b.Count > 0) {
            blocks = b;
            BLOCK_REFRESHER_DELAY = Switchster.SECOND * (int)((blocks[0].Time - blocks[blocks.Count-1].Time)*0.5);
            System.Console.WriteLine ("BLOCK_REFESHER_DELAY={0} sec.", BLOCK_REFRESHER_DELAY/Switchster.SECOND);
          }
          else {
            throw new Exception();
          }
          Thread.Sleep(BLOCK_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh blocks data for {0}. Retrying in {1} seconds.", details.name, Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
    private void MinersRefresher(){
      do {
        try {
          List<ZergMiner> m = api.Miners().Result;
          if (m.Count > 0){
            miners=m;
          }
          else {
            throw new Exception();
          }
          Thread.Sleep(Switchster.MINERS_REFRESHER_DELAY);
        }
        catch {
          System.Console.Error.WriteLine("Failed to refresh miners data for {0}. Retrying in {1} seconds.", details.name, Switchster.RETRY_DELAY/Switchster.SECOND);
          Thread.Sleep(Switchster.RETRY_DELAY);
        }
      } while (Switchster.ALIVE);
    }
  }
}