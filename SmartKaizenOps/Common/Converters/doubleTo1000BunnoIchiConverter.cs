using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKaizenOps.Common.Converters
{
    [System.Windows.Data.ValueConversion(typeof(double), typeof(double))]
    public class doubleTo1000BunnoIchiConverter : System.Windows.Data.IValueConverter
    {

        #region IValueConverter メンバ
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var target = (double)value;
            // ここに処理を記述する
            return target / 1000;
        }

        // TwoWayの場合に使用する
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
