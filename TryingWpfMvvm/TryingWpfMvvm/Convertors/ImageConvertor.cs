using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using TryingWpfMvvm.Model;

namespace TryingWpfMvvm.Convertors
{
    public class ImageConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string p = "", v = "";

            p = parameter as string;
            v = value as string;

            Uri uri = new Uri(String.Format(@"../Images/{0}{1}.jpg", p, v), UriKind.Relative);

            return new BitmapImage(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
