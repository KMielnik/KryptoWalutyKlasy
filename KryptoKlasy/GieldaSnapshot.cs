using System;

namespace KryptoKlasy
{
    public class GieldaSnapshot
    {
        public readonly double wartoscBitcoin;
        public readonly double wartoscDogecoin;
        public readonly DateTime timeStamp;

        public GieldaSnapshot(double wartoscBitcoin, double wartoscDogecoin)
        {
            this.wartoscBitcoin = wartoscBitcoin;
            this.wartoscDogecoin = wartoscDogecoin;
            timeStamp = Czity.GetPreviousDate();
        }

        public override string ToString()
        {
            return $"Data: {timeStamp.ToShortDateString()}\tBitcoin:{wartoscBitcoin:F4} BTC\tDogeCoin:{wartoscDogecoin:F4} DOGE";
        }
    }
}
