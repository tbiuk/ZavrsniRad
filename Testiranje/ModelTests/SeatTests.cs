using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace Testiranje.ModelTests
{
    [TestFixture]
    public class SeatTests
    {
        [Test]
        public void SameSeatsHaveSamePosition()
        {
            var testPosition = new Pozicija(0, 0);
            var testSeat = new Seat(testPosition, SeatAvailability.Dostupno);
            var testSameSeat = testSeat;

            Assert.IsTrue(testSeat.Pozicija.Equals(testSameSeat.Pozicija));
        }

        [Test]
        public void DifferentColumnSeatsHaveDifferentPosition()
        {
            var testPosition = new Pozicija(0, 0);
            var testDifferentColumnPosition = new Pozicija(0, 1);
            var testSeat = new Seat(testPosition, SeatAvailability.Dostupno);
            var testSameSeat = new Seat(testDifferentColumnPosition, SeatAvailability.Dostupno);

            Assert.IsFalse(testSeat.Pozicija.Equals(testSameSeat.Pozicija));
        }

        [Test]
        public void DifferentRowSeatsHaveDifferentPosition()
        {
            var testPosition = new Pozicija(0, 0);
            var testDifferentRowPosition = new Pozicija(0, 1);
            var testSeat = new Seat(testPosition, SeatAvailability.Dostupno);
            var testSameSeat = new Seat(testDifferentRowPosition, SeatAvailability.Dostupno);

            Assert.IsFalse(testSeat.Pozicija.Equals(testSameSeat.Pozicija));
        }
    }
}
