using Ninject;
using System;

namespace BusinessLogicLayer
{
    public static class IoC
    {
        #region Private Variables

        private static IKernel _kernel = new StandardKernel();

        #endregion

        #region Public Properties

        public static IKernel Kernel { get { return _kernel; } } 

        #endregion

        #region Setup

        public static void Setup()
        {
            BindViewModels();
        }

        #endregion

        private static void BindViewModels()
        {
            Kernel.Bind<MainWindowViewModel>().ToConstant(new MainWindowViewModel(DatabaseQuery.GetFilms(), DatabaseQuery.GetShowings()));
            Kernel.Bind<SeatingAreaViewModel>().ToConstant(Kernel.Get<MainWindowViewModel>().SeatingAreaViewModel);
            Kernel.Bind<FilmViewModel>().ToConstant(Kernel.Get<MainWindowViewModel>().FilmViewModel);
        }

        #region Helper Methods

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion
    }
}