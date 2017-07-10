using System;
using System.Diagnostics;
using System.Globalization;

namespace PresentationLayer
{
    public class DostupnostToImageValueConverter : BaseValueConverter<DostupnostToImageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((BusinessLogicLayer.SeatAvailability)value)
            {
                case BusinessLogicLayer.SeatAvailability.Dostupno:
                    return "/Images/Slobodno.png";

                case BusinessLogicLayer.SeatAvailability.Odabrano:
                    return "/Images/Odabrano.png";

                case BusinessLogicLayer.SeatAvailability.Zauzeto:
                    return "/Images/Zauzeto.png";

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