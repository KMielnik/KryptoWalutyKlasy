using System;

namespace KryptoKlasy
{
    public class GieldaSnapshot
    {
        public readonly float wartoscBitcoin;
        public readonly float wartoscDogecoin;
        public readonly DateTime timeStamp;

        public GieldaSnapshot(float wartoscBitcoin, float wartoscDogecoin)
        {
            this.wartoscBitcoin = wartoscBitcoin;
            this.wartoscDogecoin = wartoscDogecoin;
            timeStamp = DateTime.Now;
        }
    }
}
