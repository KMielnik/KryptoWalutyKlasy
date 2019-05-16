using System.Collections.Generic;

namespace KryptoKlasy
{
    public class Gielda
    {
        private string blockchainBitcoin;
        private string blockchainDogecoin;

        List<GieldaSnapshot> historiaSnapshotow;

        public Gielda()
        {
            historiaSnapshotow = new List<GieldaSnapshot>();
        }

        public void WygenerujIZapiszSnapshot() {
            var snapshot = WygenerujSnapshot();
            historiaSnapshotow.Add(snapshot);
        }
        public GieldaSnapshot WygenerujSnapshot()
        {
            var radnom = RandomGenerator.GetInstance();
            var snapshot = new GieldaSnapshot(
                radnom.GetRandomDouble(1000, 1200),
                radnom.GetRandomDouble(47, 124));
            return snapshot;
        }
        public List<GieldaSnapshot> PobierzHistorie() => historiaSnapshotow;
    }
}
