using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Film
    {
        #region Private Variables

        private string _name;
        private string _description;
        private TimeSpan _duratation;

        #endregion

        #region Public Properties

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public TimeSpan Duratation { get { return _duratation; } set { _duratation = value; } }

        #endregion


        #region Constructor

        public Film(string name, string description, TimeSpan duratation)
        {
            _name = name;
            _description = description;
            _duratation = duratation;
        }

        #endregion
    }
}
