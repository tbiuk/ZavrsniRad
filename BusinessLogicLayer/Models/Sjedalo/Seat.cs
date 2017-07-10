using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Seat
    {
        #region Private Variables

        private SeatAvailability _dostupnost;
        private Pozicija _pozicija;

        #endregion

        #region Public Properties

        public SeatAvailability Dostupnost { get { return _dostupnost; } set { _dostupnost = value; } }
        public Pozicija Pozicija { get { return _pozicija; } set { _pozicija = value; } }

        #endregion

        #region Constructor

        public Seat(Pozicija pozicija, SeatAvailability dostupnost) 
        {
            _pozicija = pozicija;
            _dostupnost = dostupnost;
        }

        #endregion

        #region Helper Methods

        #endregion

    }
}
