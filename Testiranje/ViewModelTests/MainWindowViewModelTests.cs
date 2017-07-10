using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace Testiranje
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel testEmpty;
        private MainWindowViewModel test3Prikaza;
        
        [SetUp]
        public void SetUp()
        {
            ObservableCollection<Film> testPopisFilmova = new ObservableCollection<Film>();
            Film Film1 = new Film("Film 1", "Opis filma 1", TimeSpan.FromHours(2));
            Film Film2 = new Film("Film 2", "Opis filma 2", TimeSpan.FromHours(2));
            Film Film3 = new Film("Film 3", "Opis filma 3", TimeSpan.FromHours(2));

            testPopisFilmova.Add(Film1);
            testPopisFilmova.Add(Film2);
            testPopisFilmova.Add(Film3);

            ObservableCollection<PrikazFilma> testPopisPrikazaFilmova = new ObservableCollection<PrikazFilma>();
            PrikazFilma Prikaz1 = new PrikazFilma(1, "Film 1", DateTime.Now, 30.0, "Dvorana 1");
            PrikazFilma Prikaz2 = new PrikazFilma(2, "Film 1", DateTime.Now, 30.0, "Dvorana 1");
            PrikazFilma Prikaz3 = new PrikazFilma(3, "Film 1", DateTime.Now, 30.0, "Dvorana 2");

            testPopisPrikazaFilmova.Add(Prikaz1);
            testPopisPrikazaFilmova.Add(Prikaz2);
            testPopisPrikazaFilmova.Add(Prikaz3);

            testEmpty = new MainWindowViewModel(new  ObservableCollection<Film>(), new ObservableCollection<PrikazFilma>());
            test3Prikaza = new MainWindowViewModel(testPopisFilmova, testPopisPrikazaFilmova);
        }
        /*
        [Test]
        public void ConstructorSArgumentom0StvaraPrazanuListuPrikaza()
        {
            Assert.AreEqual(testEmpty.FilmViewModel.Prikazi.Count, 0);
        }

        [Test]
        public void ConstructorSArgumentom3StvaraListuPrikazaS3Elementa()
        {
            Assert.AreEqual(test3Prikaza.FilmViewModel.Prikazi.Count, 3);
        }*/
 
        [Test]
        public void PostaviPrikazMijenjaPrikaz()
        {
            test3Prikaza.CurrentPrikaz = 2;
            Assert.AreEqual(test3Prikaza.CurrentPrikaz, 2);
        }
    
        //END PRIKAZI TESTS

        [Test]
        public void BaseCurrentPageIsRegister()
        {
            Assert.AreEqual(test3Prikaza.CurrentPage, ApplicationPage.Register);
        }

        [Test]
        public void ChangePageMethod()
        {
            test3Prikaza.ChangePage(ApplicationPage.Login);
            Assert.AreEqual(test3Prikaza.CurrentPage, ApplicationPage.Login);
        }
    }
}
