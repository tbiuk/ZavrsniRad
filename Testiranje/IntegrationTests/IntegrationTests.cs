using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace Testiranje.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        private SeatingAreaViewModel testSeatingAreaViewModel;
        private int testPrikaz;

        [SetUp]
        public void SetUp()
        {
            testSeatingAreaViewModel = new SeatingAreaViewModel();
            testPrikaz = 3;
        }
        [Test]
        public void ZauzimanjeSjedala()
        {
            //Postavi trenutni prikaz
            testSeatingAreaViewModel.CurrentPrikaz = testPrikaz;
            
            //Na postavljenom prikazu odabrati prazna sjedala
            testSeatingAreaViewModel.Seats.ElementAt(0).Promijeni();
            testSeatingAreaViewModel.Seats.ElementAt(12).Promijeni();
            testSeatingAreaViewModel.Seats.ElementAt(13).Promijeni();

            //Query za zauzimanje odabranih sjedala, također vrši update sjedala trenutne dvorane
            testSeatingAreaViewModel.Zauzmi(testPrikaz);

            Assert.AreEqual(testSeatingAreaViewModel.Seats.ElementAt(0).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreEqual(testSeatingAreaViewModel.Seats.ElementAt(12).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreEqual(testSeatingAreaViewModel.Seats.ElementAt(13).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreNotEqual(testSeatingAreaViewModel.Seats.ElementAt(99).Dostupnost, SeatAvailability.Zauzeto);
        }
        /*
        [Test]
        public void ZauzimanjeSjedala()
        {
            //Postavi trenutni prikaz
            testSeatingAreaViewModel.CurrentPrikaz = testPrikaz;

            //Na postavljenom prikazu odabrati prazna sjedala
            testSeatingAreaViewModel.Seats.ElementAt(0).Promijeni();
            testSeatingAreaViewModel.Seats.ElementAt(12).Promijeni();
            testSeatingAreaViewModel.Seats.ElementAt(13).Promijeni();

            //Query za zauzimanje odabranih sjedala
            testSeatingAreaViewModel.Zauzmi(testPrikaz);

            Assert.AreEqual(testSeatingAreaViewModel.Seats.ElementAt(0).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreEqual(testSeatingAreaViewModel.Seats.ElementAt(12).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreEqual(testSeatingAreaViewModel.Seats.ElementAt(13).Dostupnost, SeatAvailability.Zauzeto);
        }*/
    }
}
