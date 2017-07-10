using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using System.Collections.ObjectModel;

namespace Testiranje
{
    [TestFixture]
    public class SeatAreaViewModelTests
    {
        [Test]
        public void SeatingAreaViewModelHas100Seats()
        {
            var testSeats = new SeatingAreaViewModel().Seats;

            Assert.AreEqual(100, testSeats.Count);
        }

        [Test]
        public void RemoveSeats()
        {
            var testSeatingAreaViewModel = new SeatingAreaViewModel();
            testSeatingAreaViewModel.RemoveSeats();

            Assert.IsEmpty(testSeatingAreaViewModel.Seats);
        }

        /*
        [Test]
        public void ZauzmiMethod()
        {
            //Stvoriti novi SeatingAreaViewModel
            var testSeatingAreaViewModel = new SeatingAreaViewModel();
            //Uzeti jedno 
            var testSeatViewModel = testSeatingAreaViewModel.Seats.ElementAt<SeatViewModel>(0);

            testSeatViewModel.Promijeni();
            testSeatingAreaViewModel.Zauzmi();

            Assert.AreEqual(SeatAvailability.Zauzeto, testSeatViewModel.Dostupnost);
        }
        */
    }
}
