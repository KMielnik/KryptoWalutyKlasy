using System.Collections.Generic;

namespace KryptoKlasy
{
    public class Gielda
    {
        private string blockchainBitcoin;
        private string blockchainDogecoin;

        List<GieldaSnapshot> historiaSnapshotow;

        public void WygenerujIZapiszSnapshot() { }
        public GieldaSnapshot WygenerujSnapshot() => new GieldaSnapshot();
        public List<GieldaSnapshot> PobierzHistorie() => new List<GieldaSnapshot>();
    }
}
