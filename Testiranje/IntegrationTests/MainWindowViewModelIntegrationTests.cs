using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace Testiranje.IntegrationTests
{
    [TestFixture]
    public class MainWindowViewModelIntegrationTests
    {
        private MainWindowViewModel testViewModel;
        private ObservableCollection<Film> filmsFromDatabase;
        private ObservableCollection<PrikazFilma> showingsFromDatabase;

        [SetUp]
        public void SetUp()
        {
            filmsFromDatabase = DatabaseQuery.GetFilms();
            showingsFromDatabase = DatabaseQuery.GetShowings();
            testViewModel = new MainWindowViewModel(filmsFromDatabase, showingsFromDatabase);
        }

        [Test]
        public void DobavljaneSvihPrikazivanjaIzBaze()
        {
            Assert.AreEqual(showingsFromDatabase.Count, 4);
        }

        [Test]
        public void ChangeToFilmMetodaDobavljaIspravanBrojPrikazivanjaIzBaze()
        {
            testViewModel.ChangeToFilm(filmsFromDatabase.ElementAt(0));

            Assert.AreEqual(testViewModel.FilmViewModel.Prikazi.Count, 3);
        }

        [Test]
        public void PrviPrikazPrvogFilma()
        {
            testViewModel.ChangeToFilm(filmsFromDatabase.ElementAt(0));
            testViewModel.ChangeToPrikaz(1);

            var sjedalaPrikaza = testViewModel.SeatingAreaViewModel.Seats;

            Assert.AreEqual(sjedalaPrikaza.ElementAt(0).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreEqual(sjedalaPrikaza.ElementAt(1).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreEqual(sjedalaPrikaza.ElementAt(2).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreEqual(sjedalaPrikaza.ElementAt(3).Dostupnost, SeatAvailability.Zauzeto);
            Assert.AreNotEqual(sjedalaPrikaza.ElementAt(99).Dostupnost, SeatAvailability.Zauzeto);
        }
    }
}
