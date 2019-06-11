using System;
using KryptoKlasy;
using NUnit.Framework;

namespace KryptoKlasyTests
{
    [TestFixture]
    public class GieldaTests
    {
        Gielda gielda;
        const int ilosc_snapshotow = 10;

        [SetUp]
        public void Zainicjalizuj_gielde()
        {
            gielda = new Gielda();
            for(int i=0;i< ilosc_snapshotow; i++)
                gielda.WygenerujIZapiszSnapshot();
        }

        [Test]
        public void Historia_5_ostatnich_dni_zwraca_5_elementow()
        {
            var historia = gielda.HistoriaOstatnie5Dni();
            Assert.IsNotNull(historia);
        }

        [Test]
        public void Wygenerowany_snapshot_istnieje()
        {
            var snapshot = gielda.WygenerujSnapshot();
            Assert.IsNotNull(snapshot);
        }

        [Test]
        public void Historia_powinna_zawierac_ilosc_snapshotow()
        {
            var historia = gielda.PobierzHistorie();
            Assert.AreEqual(historia.Count, ilosc_snapshotow);
        }
    }
}
