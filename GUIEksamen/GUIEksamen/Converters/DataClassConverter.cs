using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GUIEksamen.Model;

namespace GUIEksamen.Converters
{
   public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var image = value as ImageClass;

            if (image != null)
            {
                string imagePath = Path.Combine(image.ImagePath, image.FileName);
                return new BitmapImage(new Uri(imagePath));
            }
            //Hvis der ikke er noget billede at vise
            return new BitmapImage();

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("The method or operation is not implemented.");
        }
    }
}