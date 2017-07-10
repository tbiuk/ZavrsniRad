using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PrikazFilma
    {
        #region Private Variables

        private int _idPrikaza;
        private SeatingArea _dvorana;
        private string _nazivDvorane;
        private DateTime _vrijemePrikaza;
        private string _filmName;
        private double _cijena;

        #endregion

        #region Public Properties

        public DateTime VrijemePrikaza
        {
            get { return _vrijemePrikaza; }
            set { _vrijemePrikaza = value; }
        }

        public string PrikazInfo
        {
            get { return _vrijemePrikaza.DayOfWeek.ToString() + Environment.NewLine + _vrijemePrikaza.ToShortTimeString() + Environment.NewLine + _nazivDvorane; }
        }

        public SeatingArea SeatingArea
        {
            get { return _dvorana; }
            set { _dvorana = value; }
        }

        public int ShowingID
        {
            get { return _idPrikaza; }
            set { _idPrikaza = value; }
        }

        public string FilmName
        { get { return _filmName; } set { _filmName = value; } }

        #endregion

        #region Constructor

        public PrikazFilma(int idPrikaza, string filmName, DateTime vrijemePrikaza, double cijena, string nazivDvorane)
        {
            _idPrikaza =  idPrikaza;
            _dvorana = new SeatingArea();
            _dvorana.SeatingAreaName = nazivDvorane;
            _nazivDvorane = nazivDvorane;
            _vrijemePrikaza = vrijemePrikaza;
            _cijena = cijena;
            _filmName = filmName;
        }

        #endregion
    }
}
