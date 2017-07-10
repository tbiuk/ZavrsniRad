using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace BusinessLogicLayer
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region Private Variables

        private ApplicationPage _currentPage;
        private int _currentlySelectedPrikaz;

        private ObservableCollection<Film> _films;
        private ObservableCollection<PrikazFilma> _showings;

        private SeatingAreaViewModel _seatingAreaViewModel;
        private FilmViewModel _filmViewModel;

        #endregion

        #region Public Properties

        public ApplicationPage CurrentPage { get { return _currentPage; } set { _currentPage = value; } }
        public int CurrentPrikaz { get { return _currentlySelectedPrikaz; } set { _currentlySelectedPrikaz = value; } }
        
        public ObservableCollection<Film> Films { get { return _films; } set { _films = value; } }
        public ObservableCollection<PrikazFilma> Showings { get { return _showings; } set { _showings = value; } }

        public SeatingAreaViewModel SeatingAreaViewModel { get { return _seatingAreaViewModel; } set { _seatingAreaViewModel = value; } }
        public FilmViewModel FilmViewModel { get { return _filmViewModel; } set { _filmViewModel = value; } }

        public ApplicationPage GetRegisterPage { get { return ApplicationPage.Register; } }
        public ApplicationPage GetLoginPage { get { return ApplicationPage.Login; } }

        #endregion

        #region Public Commands

        public ICommand ChangePageCommand { get; set; }
        public ICommand ChangeToFilmCommand { get; set; }
        public ICommand ChangeToPrikazCommand { get; set; }

        #endregion

        #region Constructor

        public MainWindowViewModel(ObservableCollection<Film> films, ObservableCollection<PrikazFilma> showings)
        {
            ChangePageCommand = new RelayCommandWithParameter((parameter) => ChangePage(parameter));
            ChangeToFilmCommand = new RelayCommandWithParameter((parameter) => ChangeToFilm(parameter));
            ChangeToPrikazCommand = new RelayCommandWithParameter((parameter) => ChangeToPrikaz(parameter));

            _currentPage = ApplicationPage.Register;

            _films = films;
            _showings = showings;
            _filmViewModel = new FilmViewModel();
            _seatingAreaViewModel = new SeatingAreaViewModel();
        }

        #endregion

        #region Helper Methods

        public void ChangePage(object page)
        {
            CurrentPage = (ApplicationPage)page;
        }

        public void ChangeToFilm(object film)
        {
            var _film = (Film)film;

            CurrentPage = ApplicationPage.Register;
            CurrentPage = ApplicationPage.Film;
            
            var query = _showings.Where(x => x.FilmName == _film.Name);
            _filmViewModel.Prikazi = new ObservableCollection<PrikazFilma>(query);
            
            _filmViewModel.Film = (Film)film;
        }

        public void ChangeToPrikaz(object prikazID)
        {
            var _prikazID = (int)prikazID;

            CurrentPage = ApplicationPage.Cinema;

            _seatingAreaViewModel.CurrentPrikaz = _prikazID;
            _seatingAreaViewModel.Seats.Clear();
            _seatingAreaViewModel.Seats = DatabaseQuery.GetReservedSeats(_prikazID);
        }

        #endregion

    }
}
