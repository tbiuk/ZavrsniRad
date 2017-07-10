using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class SeatingArea
    {
        #region Private Variables

        private List<Seat> _seats;
        private string _seatingAreaName;

        #endregion

        #region Public Properties

        public string SeatingAreaName { get { return _seatingAreaName; } set { _seatingAreaName = value; } }

        public List<Seat> Seats 
        {
            get { return _seats; }
            //set { _seats = value; }
        }

        #endregion

        #region Constructor

        public SeatingArea()
        {
            _seats = new List<Seat>(); 

            int row;
            int column;
            for (row = 0; row < 10; row++)
                for (column = 0; column < 10; column++)
                {
                    _seats.Add(new Seat(new Pozicija(row, column), SeatAvailability.Dostupno));
                }   
        }

        /*
        public SeatingArea(List<Seat> seats)
        {
            _seats = seats;
        }*/

        #endregion
    }
}
