using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Rezervacija
    {
        #region Private Variables
        
        private List<Seat> _seats = new List<Seat>();
        private int _userID;
        private PrikazFilma _prikazFilma;
        private DateTime _vrijemeRezervacije;

        #endregion

        #region Public Properties


        #endregion

        #region Constructor

        public Rezervacija()
        {
        }

        #endregion
    }
}