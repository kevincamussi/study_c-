﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTeste.Converters
{
    public class ZeroToEmptyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int && (int)value == 0)
            {
                return string.Empty;
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if (string.IsNullOrEmpty(value as string))
           {
                return 0;
           }

            if (int.TryParse(value as string, out int result)) 
            {
                return result;
            }
            return 0;

        }
    }
}
