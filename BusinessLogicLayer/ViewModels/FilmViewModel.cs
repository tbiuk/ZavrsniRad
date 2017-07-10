using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace BusinessLogicLayer
{
    public class FilmViewModel : BaseViewModel
    {

        #region Private Variables

        private ObservableCollection<PrikazFilma> _prikazi;
        private Film _film;

        #endregion

        #region Public Properties

        public Film Film { get { return _film; } set { _film = value; } }
        public string Name { get { return _film.Name; } set { _film.Name = value; } }
        public string Description { get { return _film.Description; } set { _film.Description = value; } }
        public TimeSpan Duratation { get { return _film.Duratation; } set { _film.Duratation = value; } }

        public ObservableCollection<PrikazFilma> Prikazi { get { return _prikazi; } set { _prikazi = value; } }

        #endregion

        #region Public Commands

        #endregion

        #region Constructor

        public FilmViewModel()
        {
        }

        #endregion

        #region Helper Methods

        #endregion

    }
}
