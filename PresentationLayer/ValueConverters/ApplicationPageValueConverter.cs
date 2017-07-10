using System;
using System.Diagnostics;
using System.Globalization;

namespace PresentationLayer
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {

        public ApplicationPageValueConverter()
        {
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((BusinessLogicLayer.ApplicationPage)value)
            {
                case BusinessLogicLayer.ApplicationPage.Cinema:
                    return new Cinema();

                case BusinessLogicLayer.ApplicationPage.Register:
                    return new Register();

                case BusinessLogicLayer.ApplicationPage.Login:
                    return new Login();

                case BusinessLogicLayer.ApplicationPage.Film:
                    return new Film();    

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}