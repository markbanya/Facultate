using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace runWPFrun
{

    #region RaceTrackWidthConverter

    /// <summary>
    /// Determines how wide a RacePerson's progress indicator should be, based on how far into the race it is.
    /// </summary>
    public class RaceProgressIndicatorWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int percentComplete = (int)values[0];
            double availableWidth = (double)values[1];
            double width = Math.Floor(availableWidth * (percentComplete / 100.0));
            // Reduce the final width by a little bit to avoid a minor rendering overlap.
            return percentComplete == 100 ? width - 4 : width;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    #endregion // RaceTrackWidthConverter	
}
