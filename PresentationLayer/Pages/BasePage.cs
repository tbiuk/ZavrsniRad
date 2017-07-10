using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;

namespace PresentationLayer
{
    public class BasePage : Page
    {
        private PageAnimation _pageLoadAnimation = PageAnimation.SlideAndFadeInFromRight;
        private PageAnimation _pageUnloadAnimation = PageAnimation.SlideAndFadeOutToLeft;
        private int _slideSeconds = 1;

        public PageAnimation PageLoadAnimation { get { return _pageLoadAnimation; } set { _pageLoadAnimation = value; } }
        public PageAnimation PageUnloadAnimation { get { return _pageUnloadAnimation; } set { _pageUnloadAnimation = value; } }
        public int SlideSeconds { get { return _slideSeconds; } set { _slideSeconds = value; } }

        #region Constructor

        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            this.Loaded += BasePage_Loaded;
        }

        #endregion

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    await this.SlideInFromRight(this.SlideSeconds);

                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeftAsync(this.SlideSeconds);

                    break;
            }
        }

    }
}