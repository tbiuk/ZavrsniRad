using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace Testiranje
{
    [TestFixture]
    public class SeatViewModelTests
    {
        private Seat testDostupnoSjedalo;
        private Seat testOdabranoSjedalo;
        private Seat testZauzetoSjedalo;

        [SetUp]
        public void SetUp()
        {
            testDostupnoSjedalo = new Seat(null, SeatAvailability.Dostupno);
            testOdabranoSjedalo = new Seat(null, SeatAvailability.Odabrano);
            testZauzetoSjedalo = new Seat(null, SeatAvailability.Zauzeto);
        }
        [Test]
        public void PromijeniMetodaMijenjaDostupnoSjedalo()
        {
            var testSeatViewModel = new SeatViewModel(testDostupnoSjedalo);

            testSeatViewModel.Promijeni();

            Assert.AreEqual(SeatAvailability.Odabrano, testSeatViewModel.Dostupnost);
        }

        [Test]
        public void PromijeniMetodaMijenjaOdabranoSjedalo()
        {
            var testSeatViewModel = new SeatViewModel(testOdabranoSjedalo);

            testSeatViewModel.Promijeni();

            Assert.AreEqual(SeatAvailability.Dostupno, testSeatViewModel.Dostupnost);
        }

        [Test]
        public void PromijeniMetodaNeMijenjaZauzetoSjedalo()
        {
            var testSeatViewModel = new SeatViewModel(testZauzetoSjedalo);

            testSeatViewModel.Promijeni();

            Assert.AreEqual(SeatAvailability.Zauzeto, testSeatViewModel.Dostupnost);
        }
    }
}
