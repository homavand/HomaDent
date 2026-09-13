

using System;
using Dentistry.Class;

namespace Dentistry.UserControls
{
    public class PersianMonthCalendarEventArgs : EventArgs
    {
        public PersianDate CurrentValue { get; set; }

        public PersianDate OldValue { get; set; }
    }
}