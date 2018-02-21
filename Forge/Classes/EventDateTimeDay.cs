using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class EventDateTimeDay : PropertyChangedBase
    {
        private int _day;
        private string _dayOfTheWeek;

        public int Day
        {
            get { return _day; }
            set
            {
                if(_day != value)
                {
                    _day = value;
                    NotifyOfPropertyChange(() => Day);
                }
            }
        }
        public string DayOfTheWeek
        {
            get { return _dayOfTheWeek; }
            set
            {
                if(_dayOfTheWeek != value)
                {
                    _dayOfTheWeek = value;
                    NotifyOfPropertyChange(() => DayOfTheWeek);
                }
            }
        }
    }
}
