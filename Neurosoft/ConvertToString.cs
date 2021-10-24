using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Neurosoft
{
    class ConvertToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ParametrType parametrValueType)
            {
                switch (parametrValueType)
                {
                    case ParametrType.simpleString:
                        return "Простая строка";
                    case ParametrType.stringWithHistory:
                        return "Строка с историей";
                    case ParametrType.valueFromList:
                        return "Значение из списка";
                    case ParametrType.SetOfValueFromList:
                        return "Набор значений из списка";
                    default:
                        break;
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
