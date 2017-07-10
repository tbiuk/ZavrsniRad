using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace PresentationLayer
{
    public class ViewModelLocator
    {
        private static ViewModelLocator _instance;

        #region Public Properties

        public static ViewModelLocator Instance 
        { 
            get 
            {
                if(_instance == null)
                    _instance = new ViewModelLocator();
                return _instance;
            } 
        }

        public static MainWindowViewModel MainWindowViewModel { get { return IoC.Get<MainWindowViewModel>(); } }
        public static SeatingAreaViewModel SeatingAreaViewModel { get { return IoC.Get<SeatingAreaViewModel>(); } }
        public static FilmViewModel FilmViewModel { get { return IoC.Get<FilmViewModel>(); } }

        #endregion
    }
}