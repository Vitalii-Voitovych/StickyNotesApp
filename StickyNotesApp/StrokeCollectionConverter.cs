using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Ink;

namespace StickyNotesApp
{
    public class StrokeCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StrokeCollection strokes;
            if (value == null) return value!;
            using (MemoryStream ms = new MemoryStream((byte[])value))
            {
                strokes = new StrokeCollection(ms);
            }
            return strokes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
