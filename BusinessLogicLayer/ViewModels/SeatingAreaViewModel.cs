using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace BusinessLogicLayer
{
    public class SeatingAreaViewModel : BaseViewModel
    {

        #region Private Variables

        private int _currentlySelectedPrikaz;

        #endregion

        #region Public Properties

        public ObservableCollection<SeatViewModel> Seats { get; set; }
        public int CurrentPrikaz { get { return _currentlySelectedPrikaz; } set { _currentlySelectedPrikaz = value; } }

        #endregion

        #region Public Commands

        public ICommand ZauzmiCommand { get; set; }

        #endregion

        #region Constructor

        public SeatingAreaViewModel()
        {
            ZauzmiCommand = new RelayCommandWithParameter((parameter) => Zauzmi(parameter));

            CreateEmptySeatingArea();
        }

        #endregion

        #region Helper Methods

        public void CreateEmptySeatingArea()
        {
            Seats = new ObservableCollection<SeatViewModel>(
                new SeatingArea().Seats.Select(content => new SeatViewModel(content)));
        }

        public void RemoveSeats()
        {
            Seats.Clear();
        }

        public void Zauzmi(object selectedShowing)
        {
            var selectedSeats = new List<Seat>();
            foreach(SeatViewModel element in Seats)
                if (element.Dostupnost == SeatAvailability.Odabrano)
                {
                    var row = element.GetSeat.Pozicija.GetRowPosition;
                    var column = element.GetSeat.Pozicija.GetColumnPosition;
                    selectedSeats.Add(new Seat(new Pozicija(row, column), SeatAvailability.Odabrano));
                }
            DatabaseQuery.AddReservation(selectedSeats, _currentlySelectedPrikaz);
            UpdateSeats(DatabaseQuery.GetReservedSeats((int)selectedShowing));
        }

        public void UpdateSeats(ObservableCollection<SeatViewModel> updatedSeats)
        {
            Seats = updatedSeats;
        }

        #endregion

    }
}
