using System;
using System.Diagnostics;
using System.Globalization;
using Datarynx.Enums;
using Xamarin.Forms;

namespace Datarynx.Converters
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class TaskStateToObjectConverter<T> : IValueConverter
    {
        public T NotStartedObject { get; set; }
        public T InProgressObject { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (TaskState)value;
            return state == TaskState.NotStarted ? NotStartedObject : InProgressObject;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
