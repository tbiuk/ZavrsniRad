using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Pozicija
    {
        #region Private Variables

        private int _seatRow;
        private int _seatColumn;

        #endregion

        #region Public Properties

        public int GetRowPosition
        {
            get{ return this._seatRow; }
        }

        public int GetColumnPosition
        {
            get { return this._seatColumn; }
        }

        #endregion

        #region Constructor

        public Pozicija(int row, int column)
        {
            this._seatColumn = column;
            this._seatRow = row;
        }

        #endregion

        #region Override Methods

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Pozicija pozicija = obj as Pozicija;
            if (pozicija.GetRowPosition == this.GetRowPosition && pozicija.GetColumnPosition == this.GetColumnPosition)
                return true;
            return false;
        }

        #endregion
    }
}
