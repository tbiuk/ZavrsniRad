using System.ComponentModel;
using System.Windows.Input;

namespace BusinessLogicLayer
{
    public class SeatViewModel : BaseViewModel
    {

        #region Private Variables
        
        private Seat _seat;
        private SeatAvailability _dostupnost;

        #endregion

        #region Public Properties

        public int posX { get { return _seat.Pozicija.GetRowPosition * 70; } }
        public int posY { get { return _seat.Pozicija.GetColumnPosition * 50; } }
        public SeatAvailability Dostupnost { get { return _dostupnost; } set { _dostupnost = value; } }
        public Seat GetSeat { get { return _seat; } }

        #endregion

        #region Public Commands

        public ICommand PromijeniCommand { get; set; }

        #endregion

        #region Constructor

        public SeatViewModel(Seat seat)
        {
            this.PromijeniCommand = new RelayCommand(Promijeni);

            _seat = seat;
            // Nepoznati problem
            // Property "Dostupnost" se čudno ponaša s IPropertyChanged ako se mijenja varijabla izvan viewmodela
            _dostupnost = _seat.Dostupnost;
        }

        #endregion

        #region Helper Methods

        public void Promijeni()
        {
            if (Dostupnost == SeatAvailability.Dostupno)
                Dostupnost = SeatAvailability.Odabrano;
            else if (Dostupnost == SeatAvailability.Odabrano)
                Dostupnost = SeatAvailability.Dostupno;
        }

        #endregion
    }
}
