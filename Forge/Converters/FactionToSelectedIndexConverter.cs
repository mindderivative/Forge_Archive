using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Forge.Converters
{
    class FactionToSelectedIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string faction = value.ToString();

            switch (faction)
            {
                case "Hostile":
                    return 0;
                case "Unfriendly":
                    return 1;
                case "Neutral":
                    return 2;
                case "Friendly":
                    return 3;
                case "Honored":
                    return 4;
                case "Respected":
                    return 5;
                case "Revered":
                    return 6;
                default:
                    return -1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int faction = (int)value;

            switch (faction)
            {
                case 0:
                    return "Hostile";
                case 1:
                    return "Unfriendly";
                case 2:
                    return "Neutral";
                case 3:
                    return "Friendly";
                case 4:
                    return "Honored";
                case 5:
                    return "Respected";
                case 6:
                    return "Revered";
                default:
                    return "Neutral";
            }
        }
    }
}
